using NLayer.Core.DTOs.Concert;
using NLayer.Core.Utilities.Results.Abstract;

namespace NLayer.Core.Services
{
    public interface IProductService
    {
        /// <summary>
        /// ProductId parametresine ait değeri çeker.
        /// </summary>
        /// <param name="productId">0'dan büyük bir integer Id değeri</param>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucunu DataResult tpinde geriye döner.</returns>
        Task<IDataResult<ProductDto>> GetAsync(int productId);
        /// <summary>
        /// Tüm ürünleri filtresiz bir şekilde çeker.
        /// </summary>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucunu DataResult tpinde geriye döner.</returns>
        Task<IDataResult<ProductListDto>> GetAllAsync();
        /// <summary>
        /// Silinmemiş olan tüm ürünleri çeker
        /// </summary>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucunu DataResult tpinde geriye döner.</returns>
        Task<IDataResult<ProductListDto>> GetAllByNonDeletedAsync();
        /// <summary>
        ///  Silinmemiş ve Aktif olan tüm ürünleri çeker.
        /// </summary>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucunu DataResult tipinde geriye döner.</returns>
        Task<IDataResult<ProductListDto>> GetAllByNonDeletedAndActiveAsync();
        /// <summary>
        /// Silinmiş olan tüm ürünleri çeker.
        /// </summary>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucunu DataResult tipinde geriye döner.</returns>
        Task<IDataResult<ProductListDto>> GetAllByDeletedAsync();
        /// <summary>
        /// İndirimli olan tüm ürünleri çeker.
        /// </summary>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucunu DataResult tipinde geriye döner.</returns>
        Task<IDataResult<ProductListDto>> GetAllByDiscountedAsync();
        /// <summary>
        /// Verilen count parametresi ile tarihe göre değerleri getirir. Parametre null geçilebilir.
        /// </summary>
        /// <param name="count"> -1'den büyük bir int değer alır veya null geçilebilir.</param>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucunu DataResult tipinde geriye döner.</returns>
        Task<IDataResult<ProductListDto>> GetLastProductsAsync(int? count);
        /// <summary>
        /// CategoryId parametresine sahip olan tüm ürünleri getirir.
        /// </summary>
        /// <param name="categoryId">0'dan büyük int bir ID değeri.</param>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucunu DataResult tipinde geriye döner.</returns>
        ///  /// <summary>
        /// Count parametresi kadar en çok satışı yapılan ürünleri getirir.Parametre verilmezse tüm ürünleri getirir.
        /// </summary>
        /// <param name="count">0'a eşit veya 0'dan büyük bir integer ID değeri.</param>
        /// <returns>İşlem sonucunu DataResult tipinde geriye döner.</returns>
        IDataResult<ProductListDto> GetBestSellers(int? count);        
        /// <summary>
        /// Count paremtre değeri kadar ürünleri çeker.
        /// </summary>
        /// <param name="count">Nullable. 0'a eşit veya 0'dan büyük bir int değer</param>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucunu DataResult tipinde geriye döner.</returns>
        Task<IDataResult<ProductListDto>> GetTrendProductsAsync(int? count);
        /// <summary>
        /// Fiyatına göre filtreler ve paremetresi kadar ürün çeker.
        /// </summary>
        /// <param name="isAscending">bool tip.</param>
        /// <param name="takeSize">Nullable olan ve 0'dan büyük bir int değer.</param>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucunu DataResult tipinde geriye döner.</returns>
        Task<IDataResult<ProductListDto>> GetAllByPriceCountAsync(bool isAscending, int? takeSize);
        /// <summary>
        /// CategoryId parametresindeki Id değerine sahip ürünleri çeker.
        /// </summary>
        /// <param name="categoryId">0'dan büyük bir int ID değer.</param>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucunu DataResult tipinde geriye döner.</returns>
        Task<IDataResult<ProductListDto>> GetAllByCategoryAsync(int categoryId);     
        /// <summary>
        /// Verilen ID parametresine ait product'ın ProductUpdateDto temsilini geriye döner.
        /// </summary>
        /// <param name="productId">0'dan büyük int bir ID değeri.</param>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucunu DataResult tipinde geriye döner.</returns>
        Task<IDataResult<ProductUpdateDto>> GetProductUpdateDtoAsync(int productId);            
        /// <summary>
        /// Verilen parametrelere göre filtreleme yapar ve sayfalama operasyonları gerçekleştirir.
        /// </summary>
        /// <param name="categoryId">Nullable 0'dan büyük bir int Id değeri.</param>
        /// <param name="currentPage">0'dan büyük, default olarak int '1' değerine sahip veya 1'den daha büyük bir int değer. </param>
        /// <param name="PageSize">0'dan büyük, default olarak int '6' değerine sahip veya daha büyük bir int değer.</param>
        /// <param name="isAscending">default olarak true gelen bool tip.</param>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucunu DataResult tipinde geriye döner.</returns>
        Task<IDataResult<ProductListDto>> GetAllByPagingAsync(int? categoryId,int currentPage=1, int PageSize=6, bool isAscending=true);
        /// <summary>
        /// Verilen paremetrelere göre arama operasyonu gerçekleştirir.
        /// </summary>
        /// <param name="keyword">string bir key.</param>
        /// <param name="currentPage">0'dan büyük, default olarak int '1' değerine sahip veya 1'den daha büyük bir int değer. </param>
        /// <param name="pageSize">0'dan büyük, default olarak int '6' değerine sahip veya daha büyük bir int değer.</param>
        /// <param name="isAscending">default olarak true gelen bool tip.</param>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucunu DataResult tipinde geriye döner.</returns>
        Task<IDataResult<ProductListDto>> SearchAsync(string keyword, int currentPage = 1, int pageSize = 6, bool isAscending = true);         
        /// <summary>
        /// Verilen ProductAddDto ve CreatedByName parametreleri ile birlikte yeni bir Ürün ekler.
        /// </summary>
        /// <param name="productAddDto">productAddDto tipinde eklenecek ürün bilgileri.</param>
        /// <param name="createdByName">string tipinde bir değer alır.</param>
        /// <returns>Asenkron bir operasyon ile Task olarak işlemin sonucunu DataResult tipinde döner.</returns>
        Task<IDataResult<ProductDto>> AddAsync(ProductAddDto productAddDto, string createdByName);
        /// <summary>
        /// Verilen ProductUpdateDto ve modifiedByName parametreleri ile birlikte seçili ürünü günceller.
        /// </summary>
        /// <param name="productUpdateDto">ProductUpdateDto tipinde bir değer alır.</param>
        /// <param name="modifiedByName">string tipinde bir değer alır</param>
        /// <returns>Asenkron bir operasyon ile Task olarak işlemin sonucunu DataResult tipinde döner.</returns>
        Task<IDataResult<ProductDto>> UpdateAsync(ProductUpdateDto productUpdateDto, string modifiedByName);
        /// <summary>
        /// ProductId parametresi ile nesnenin IsDeleted özelliğini true olarak işaretler. Veriyi biz tamamen silene kadar veritabanında tutar.
        /// </summary>
        /// <param name="productId">0'dan büyük bir integer ID değeri.</param>
        /// <param name="modifiedByName">string tipinde bir değer alır</param>
        /// <returns>Asenkron bir operasyon ile Task olarak işlemin sonucunu DataResult tipinde döner.</returns>
        Task<IResult> DeleteAsync(int productId, string modifiedByName);
        /// <summary>
        /// ProductId parametresine ait silinmiş verileri geri getirir.
        /// </summary>
        /// <param name="productId">0'dan büyük bir integer ID değeri.</param>
        /// <param name="modifiedByName">string tipinde bir değer alır</param>
        /// <returns>Asenkron bir operasyon ile Task olarak işlemin sonucunu DataResult tipinde döner.</returns>
        Task<IResult> UndoDeleteAsync(int productId, string modifiedByName);
        /// <summary>
        /// ProductId parametresine ait veriyi veritabanından tamamen siler!
        /// </summary>
        /// <param name="productId">0'dan büyük bir integer ID değeri.</param>
        /// <returns></returns>
        Task<IResult> HardDeleteAsync(int productId);
        /// <summary>
        /// int gibi sayısal dönüş tipine sahip değerlerin sayısal değerlerini hesaplar.
        /// </summary>
        /// <returns>Asenkron bir operasyon ile Task olarak işlemin sonucunu DataResult tipinde döner.</returns>
        Task<IDataResult<int>> CountAsync();
        /// <summary>
        /// Silinmemiş olan nesnelere ait int gibi sayısal dönüş tipine sahip değerlerin sayısal değerlerini hesaplar.
        /// </summary>
        /// <returns>Asenkron bir operasyon ile Task olarak işlemin sonucunu DataResult tipinde döner.</returns>
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
