using AutoMapper;
using NLayer.Core.DTOs.Concert;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Core.Utilities.Results.Abstract;
using NLayer.Core.Utilities.Results.ComplexTypes;
using NLayer.Core.Utilities.Results.Concert;
using NLayer.Service.Utilities;
using System.Linq.Expressions;
using Product = NLayer.Core.Entities.Concert.Product;

namespace NLayer.Service.Services
{
    public class ProductManager : ManagerBase, IProductService
    {
        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        // Fiyatına göre çoktan aza, azdan çoka/Daha sonra düzenleme yapabilirim.
        public async Task<IDataResult<ProductListDto>> GetAllByPriceCountAsync(bool isAscending, int? takeSize)
        {
            var products = await UnitOfWork.Products.GetAllAsync(p => p.IsActive && !p.IsDeleted, p => p.Category);
            var sortedProducts = isAscending
                ? products.OrderBy(p => p.Price)
                : products.OrderByDescending(p => p.Price);
            return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
            {
                Products = takeSize == null ? sortedProducts.ToList() : sortedProducts.Take(takeSize.Value).ToList()
            });
        }
        public async Task<IDataResult<ProductListDto>> GetAllByPagingAsync(int? categoryId, int currentPage = 1, int pageSize = 6, bool isAscending = true)
        {
            // Dışardan bir değer girilmesi durumunda, sınırların dışına çıkılmasını engelliyorum.
            pageSize = pageSize > 18 ? 18 : pageSize;
            pageSize = pageSize < 6 ? 6 : pageSize;
            var products = categoryId == null
                ? await UnitOfWork.Products.GetAllAsync(p => p.IsActive && !p.IsDeleted, p => p.Category)
                : await UnitOfWork.Products.GetAllAsync(p => p.CategoryId == categoryId && p.IsActive && !p.IsDeleted, p => p.Category);
            var sortedProducts = isAscending ? products.OrderBy(p => p.Price).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList() : products.OrderByDescending(p => p.Price).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
            {
                Products = sortedProducts,
                CategoryId = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = products.Count,
                IsAscending = isAscending
            });
        }
        public async Task<IDataResult<ProductListDto>> SearchAsync(string keyword, int currentPage = 1, int pageSize = 6, bool isAscending = true)
        {
            pageSize = pageSize > 18 ? 18 : pageSize;
            pageSize = pageSize < 6 ? 6 : pageSize;
            if (string.IsNullOrWhiteSpace(keyword))
            {
                var products = await UnitOfWork.Products.GetAllAsync(p => p.IsActive && !p.IsDeleted, p => p.Category);
                var sortedProducts = isAscending
                    ? products.OrderBy(p => p.Price).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                    : products.OrderByDescending(p => p.Price).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Products = sortedProducts,
                    CurrentPage = currentPage,
                    PageSize = pageSize,
                    TotalCount = products.Count,
                    IsAscending = isAscending
                });
            }

            var searchedProducts = await UnitOfWork.Products.SearchAsync(new List<Expression<Func<Product, bool>>>
            {
              (p)=>p.Name.Contains(keyword),
              (p)=>p.Category.Name.Contains(keyword),
            },
            p => p.Category);
            var searchedAndSortedProducts = isAscending
                    ? searchedProducts.OrderBy(p => p.Price).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                    : searchedProducts.OrderByDescending(p => p.Price).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
            {
                Products = searchedAndSortedProducts,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = searchedProducts.Count,
                IsAscending = isAscending
            });
        }     
        public IDataResult<ProductListDto> GetBestSellers(int? count)
        {
            var products = UnitOfWork.Products.GetBestSellers(count.Value);
            if (products.Count > -1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Products = products,
                    ResultStatusBase = ResultStatus.Success,

                });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: true), null);
        }
        // Trend ürünler, en çok beğeni alana göre sıralanabilir. Yıldız hesaplama kodu ile burası tekrar düzenlenecek.
        public async Task<IDataResult<ProductListDto>> GetTrendProductsAsync(int? count)
        {
            var products = await UnitOfWork.Products.GetAllAsync(p => p.IsActive && !p.IsDeleted, p => p.Category);
            var result = products.AsEnumerable().OrderByDescending(p => p.StarGivenUserCount).Take(count.Value).ToList();
            if (result.Count > -1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Products = result,
                    ResultStatusBase = ResultStatus.Success
                });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: true), null);
        }
        public async Task<IDataResult<ProductListDto>> GetLastProductsAsync(int? count)
        {
            var products = await UnitOfWork.Products.GetAllAsync(p => p.IsActive && !p.IsDeleted, p => p.Category, p => p.Comments);
            var result = count != null
                ? products.AsEnumerable().OrderByDescending(p => p.CreatedDate).Take(count.Value).ToList()
                : products.AsEnumerable().OrderByDescending(p => p.CreatedDate).ToList();
            if (products != null && result.Count > -1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Products = result,
                    ResultStatusBase = ResultStatus.Success
                });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: true), null);
        }
        public async Task<IDataResult<ProductDto>> GetAsync(int productId)
        {
            var product = await UnitOfWork.Products.GetAsync(p => p.Id == productId, p => p.Category);
            if (product != null)
            {
                product.Comments = await UnitOfWork.Comments.GetAllAsync(c => c.ProductId == productId && !c.IsDeleted && c.IsActive);
                return new DataResult<ProductDto>(ResultStatus.Success, new ProductDto
                {
                    Product = product,
                    ResultStatusBase = ResultStatus.Success
                });
            }
            return new DataResult<ProductDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: false), null);
        }
        public async Task<IDataResult<ProductListDto>> GetAllAsync()
        {
            var products = await UnitOfWork.Products.GetAllAsync(null, p => p.Category);
            if (products.Count > -1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Products = products,
                    ResultStatusBase = ResultStatus.Success
                });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: true), null); ;
        }
        public async Task<IDataResult<ProductListDto>> GetAllByCategoryAsync(int categoryId)
        {
            var result = await UnitOfWork.Categories.AnyAsync(c => c.Id == categoryId);
            if (result)
            {
                var products = await UnitOfWork.Products.GetAllAsync(p => p.CategoryId == categoryId && !p.IsDeleted && p.IsActive, p => p.Category);
                if (products.Count > -1)
                {
                    return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                    {
                        Products = products,
                        ResultStatusBase = ResultStatus.Success
                    });
                }
                return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: true), null);
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: false), null);
        }
        public async Task<IDataResult<ProductListDto>> GetAllByDiscountedAsync()
        {
            var products = await UnitOfWork.Products.GetAllAsync(p => p.IsDiscounted && p.IsActive && !p.IsDeleted, p => p.Category);
            if (products.Count > -1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Products = products,
                    ResultStatusBase = ResultStatus.Success
                });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: true), null);
        }
        public async Task<IDataResult<ProductListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var products = await UnitOfWork.Products.GetAllAsync(p => !p.IsDeleted && p.IsActive, p => p.Category);
            if (products.Count > -1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Products = products,
                    ResultStatusBase = ResultStatus.Success
                });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: true), null);
        }
        public async Task<IDataResult<ProductListDto>> GetAllByNonDeletedAsync()
        {
            var products = await UnitOfWork.Products.GetAllAsync(p => !p.IsDeleted, p => p.Category, p => p.Comments, p => p.OrderDetails);
            //throw new SqlNullValueException();
            if (products.Count > -1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Products = products,
                    ResultStatusBase = ResultStatus.Success
                });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: true), null);
        }
        public async Task<IDataResult<ProductListDto>> GetAllByDeletedAsync()
        {
            var products = await UnitOfWork.Products.GetAllAsync(p => p.IsDeleted, p => p.Category, c => c.Comments);
            if (products.Count > -1)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto
                {
                    Products = products,
                    ResultStatusBase = ResultStatus.Success
                });
            }
            return new DataResult<ProductListDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: true), null);
        }
        public async Task<IDataResult<ProductUpdateDto>> GetProductUpdateDtoAsync(int productId)
        {
            var result = await UnitOfWork.Products.AnyAsync(p => p.Id == productId);
            if (result)
            {
                var product = await UnitOfWork.Products.GetAsync(p => p.Id == productId);
                var productUpdateDto = Mapper.Map<ProductUpdateDto>(product);
                return new DataResult<ProductUpdateDto>(ResultStatus.Success, productUpdateDto);
            }
            else
            {
                return new DataResult<ProductUpdateDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: false), null);
            }
        }
        public async Task<IDataResult<ProductDto>> AddAsync(ProductAddDto productAddDto, string createdByName)
        {
            var product = Mapper.Map<Product>(productAddDto);
            product.CreatedByName = createdByName;
            product.ModifiedByName = createdByName;
            var addedProduct = await UnitOfWork.Products.AddAsync(product);
            await UnitOfWork.CommitAsync();
            return new DataResult<ProductDto>(ResultStatus.Success, Messages.Product.Add(addedProduct.Name), new ProductDto
            {
                Product = addedProduct,
                ResultStatusBase = ResultStatus.Success,
                MessageBase = Messages.Product.Add(addedProduct.Name)
            });
        }
        public async Task<IDataResult<ProductDto>> UpdateAsync(ProductUpdateDto productUpdateDto, string modifiedByName)
        {
            var oldProduct = await UnitOfWork.Products.GetAsync(p => p.Id == productUpdateDto.Id);
            if (oldProduct != null)
            {

                var product = Mapper.Map<ProductUpdateDto, Product>(productUpdateDto, oldProduct);
                product.ModifiedByName = modifiedByName;
                var updatedProduct = await UnitOfWork.Products.UpdateAsync(product);
                await UnitOfWork.CommitAsync();
                return new DataResult<ProductDto>(ResultStatus.Success, Messages.Product.Update(updatedProduct.Name), new ProductDto
                {
                    Product = updatedProduct,
                    ResultStatusBase = ResultStatus.Success,
                    MessageBase = Messages.Product.Update(updatedProduct.Name)
                });
            }
            else
            {
                return new DataResult<ProductDto>(ResultStatus.Error, Messages.Product.NotFound(isPlural: false), new ProductDto
                {
                    Product = null,
                    ResultStatusBase = ResultStatus.Error,
                    MessageBase = Messages.Product.NotFound(isPlural: false)
                });
            }
        }
        public async Task<IResult> DeleteAsync(int productId, string modifiedByName)
        {
            var result = await UnitOfWork.Products.AnyAsync(p => p.Id == productId);
            if (result)
            {
                var product = await UnitOfWork.Products.GetAsync(p => p.Id == productId);
                product.IsDeleted = true;
                product.IsActive = false;
                product.ModifiedByName = modifiedByName;
                product.ModifiedDate = DateTime.Now;
                var deletedProduct = await UnitOfWork.Products.UpdateAsync(product);
                await UnitOfWork.CommitAsync();
                return new Result(ResultStatus.Success, Messages.Product.Delete(product.Name));
            }
            return new Result(ResultStatus.Success, Messages.Product.NotFound(isPlural: false));
        }
        public async Task<IResult> HardDeleteAsync(int productId)
        {
            var result = await UnitOfWork.Products.AnyAsync(p => p.Id == productId);
            if (result)
            {
                var product = await UnitOfWork.Products.GetAsync(p => p.Id == productId);
                await UnitOfWork.Products.DeleteAsync(product);
                await UnitOfWork.CommitAsync();
                return new Result(ResultStatus.Success, Messages.Product.HardDelete(product.Name));
            }
            return new Result(ResultStatus.Error, Messages.Product.NotFound(isPlural: false));
        }
        public async Task<IResult> UndoDeleteAsync(int productId, string modifiedByName)
        {
            var result = await UnitOfWork.Products.AnyAsync(p => p.Id == productId);
            if (result)
            {
                var product = await UnitOfWork.Products.GetAsync(p => p.Id == productId);
                product.IsDeleted = false;
                product.IsActive = true;
                product.ModifiedByName = modifiedByName;
                product.ModifiedDate = DateTime.Now;
                var deletedProduct = await UnitOfWork.Products.UpdateAsync(product);
                await UnitOfWork.CommitAsync();
                return new Result(ResultStatus.Success, Messages.Product.UndoDelete(product.Name));
            }
            return new Result(ResultStatus.Success, Messages.Product.NotFound(isPlural: false));
        }
        public async Task<IDataResult<int>> CountAsync()
        {
            var productsCount = await UnitOfWork.Products.CountAsync();
            if (productsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, productsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Success, $"Beklenmeyen bir hata oluştu.", -1);
            }
        }
        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var productsCount = await UnitOfWork.Products.CountAsync(c => c.IsDeleted == false);
            if (productsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, productsCount);
            }
            else
            {
                return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata oluştu.", -1);
            }
        }
    }
}
