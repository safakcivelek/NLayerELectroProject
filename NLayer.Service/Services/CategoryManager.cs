using AutoMapper;
using NLayer.Core.DTOs.Concert;
using NLayer.Core.Entities.Concert;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Core.Utilities.Results.Abstract;
using NLayer.Core.Utilities.Results.ComplexTypes;
using NLayer.Core.Utilities.Results.Concert;
using NLayer.Service.Utilities;

namespace NLayer.Service.Services
{
    public class CategoryManager : ManagerBase, ICategoryService
    {
        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        public async Task<IDataResult<CategoryListDto>> GetAllAsync()
        {
            var categories = await UnitOfWork.Categories.GetAllAsync();
            var datas = new CategoryListDto { Categories = categories };
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, datas);
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: true), null);
        }
        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var categories = await UnitOfWork.Categories.GetAllAsync(c => c.IsDeleted == false && c.IsActive == true, c => c.Products);
            var datas = new CategoryListDto { Categories = categories };
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, datas);
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: true), null);
        }
        public async Task<IDataResult<CategoryListDto>> GetAllByDeletedAsync()
        {
            var categories = await UnitOfWork.Categories.GetAllAsync(c => c.IsDeleted);
            var datas = new CategoryListDto { Categories = categories };
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, datas);
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: true), null);
        }
        public async Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAsync()
        {
            var categories = await UnitOfWork.Categories.GetAllAsync(c => c.IsDeleted == false);
            var datas = new CategoryListDto { Categories = categories };
            if (categories.Count > -1)
            {
                return new DataResult<CategoryListDto>(ResultStatus.Success, datas);
            }
            return new DataResult<CategoryListDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: true), null);
        }
        public async Task<IDataResult<CategoryDto>> GetAsync(int categoryId)
        {
            var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            var data = new CategoryDto { Category = category };
            if (category != null)
            {
                return new DataResult<CategoryDto>(ResultStatus.Success, data);
            }
            else
                return new DataResult<CategoryDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: false), null);
            // new null olan kısımda new CategoryDto{degerler} gibi success,error,message gibi durumları yönetebilirm.Bu kısım daha çok view gibi kısımlarda dönüş mesajlarımı göstermek için uygulanabilir.
        }
        public async Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto categoryAddDto, string createdByName)
        {
            var category = Mapper.Map<Category>(categoryAddDto);
            category.CreatedByName = createdByName;
            category.ModifiedByName = createdByName;
            var addedCategory = await UnitOfWork.Categories.AddAsync(category);
            var data = new CategoryDto { Category = addedCategory };
            await UnitOfWork.CommitAsync();
            return new DataResult<CategoryDto>(ResultStatus.Success, Messages.Category.Add(addedCategory.Name), data);
            //Burada hata durumunu nasıl yönetmeliyim?
            //Örneğin savechange durumuna göre 0-1 
        }
        public async Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDtoAsync(int categoryId)
        {
            var result = await UnitOfWork.Categories.AnyAsync(c => c.Id == categoryId);
            if (result)
            {
                var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);
                var categoryUpdateDto = Mapper.Map<CategoryUpdateDto>(category);
                return new DataResult<CategoryUpdateDto>(ResultStatus.Success, categoryUpdateDto);
            }
            return new DataResult<CategoryUpdateDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: false), null);
        }
        public async Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto, string modifiedByName)
        {
            var oldCategory = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryUpdateDto.Id);
            if (oldCategory != null)
            {
                var category = Mapper.Map<CategoryUpdateDto, Category>(categoryUpdateDto, oldCategory);
                category.ModifiedByName = modifiedByName;
                var updatedCategory = await UnitOfWork.Categories.UpdateAsync(category);
                await UnitOfWork.CommitAsync();
                var data = new CategoryDto { Category = updatedCategory };

                return new DataResult<CategoryDto>(ResultStatus.Success, Messages.Category.Update(updatedCategory.Name), data);
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: false), null);
        }
        public async Task<IDataResult<CategoryDto>> DeleteAsync(int categoryId, string modifiedByName)
        {
            var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                category.IsDeleted = true;
                category.IsActive = false;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                var deletedCategory = await UnitOfWork.Categories.UpdateAsync(category);
                await UnitOfWork.CommitAsync();
                return new DataResult<CategoryDto>(ResultStatus.Success, Messages.Category.Delete(deletedCategory.Name), new CategoryDto
                {
                    Category = deletedCategory,
                    ResultStatusBase = ResultStatus.Success,
                    MessageBase = Messages.Category.Delete(deletedCategory.Name)
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: false), new CategoryDto
            {
                Category = null,
                ResultStatusBase = ResultStatus.Error,
                MessageBase = Messages.Category.NotFound(isPlural: false)
            });
        }
        public async Task<IDataResult<CategoryDto>> UndoDeleteAsync(int categoryId, string modifiedByName)
        {
            var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                category.IsDeleted = false;
                category.IsActive = true;
                category.ModifiedByName = modifiedByName;
                category.ModifiedDate = DateTime.Now;
                var deletedCategory = await UnitOfWork.Categories.UpdateAsync(category);
                await UnitOfWork.CommitAsync();
                return new DataResult<CategoryDto>(ResultStatus.Success, Messages.Category.UndoDelete(deletedCategory.Name), new CategoryDto
                {
                    Category = deletedCategory,
                    ResultStatusBase = ResultStatus.Success,
                    MessageBase = Messages.Category.UndoDelete(deletedCategory.Name)
                });
            }
            return new DataResult<CategoryDto>(ResultStatus.Error, Messages.Category.NotFound(isPlural: false), new CategoryDto
            {
                Category = null,
                ResultStatusBase = ResultStatus.Error,
                MessageBase = Messages.Category.NotFound(isPlural: false)
            });
        }
        public async Task<IResult> HardDeleteAsync(int categoryId)
        {
            var category = await UnitOfWork.Categories.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                await UnitOfWork.Categories.DeleteAsync(category);
                await UnitOfWork.CommitAsync();
                return new Result(ResultStatus.Success, Messages.Category.HardDelete(category.Name));
            }
            return new Result(ResultStatus.Error, Messages.Category.NotFound(isPlural: false));
        }
        public async Task<IDataResult<int>> CountAsync()
        {
            var categoriesCount = await UnitOfWork.Categories.CountAsync();
            if (categoriesCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, categoriesCount);
            }
            return new DataResult<int>(ResultStatus.Success, $"Beklenmeyen bir hata oluştu.", -1);
        }
        public async Task<IDataResult<int>> CountByNonDeletedAsync()
        {
            var categoriesCount = await UnitOfWork.Categories.CountAsync(c => c.IsDeleted == false);
            if (categoriesCount > -1)
            {
                return new DataResult<int>(ResultStatus.Success, categoriesCount);
            }
            return new DataResult<int>(ResultStatus.Error, $"Beklenmeyen bir hata oluştu.", -1);
        }
    }
}
