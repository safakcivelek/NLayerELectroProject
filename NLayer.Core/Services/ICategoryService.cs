using NLayer.Core.DTOs.Concert;
using NLayer.Core.Utilities.Results.Abstract;

namespace NLayer.Core.Services
{
    public interface ICategoryService
    {
        /// <summary>
        /// CategoryId parametsine ait değeri çeker.
        /// </summary>
        /// <param name="categoryId">0'dan büyük bir integer ID değeri.</param>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucunu DataResult tipinde geriye döner.</returns>
        Task<IDataResult<CategoryDto>> GetAsync(int categoryId);
        /// <summary>
        /// Tüm kategorileri filtresiz bir şekilde çeker.
        /// </summary>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucunu DataResult tipinde geriye döner.</returns>
        Task<IDataResult<CategoryListDto>> GetAllAsync();      
        /// <summary>
        /// Silinmemiş olan tüm kategorileri çeker.
        /// </summary>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucunu DataResult tipinde geriye döner.</returns>
        Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAsync();
        /// <summary>
        ///  Silinmemiş ve Aktif olan tüm kategorileri çeker.
        /// </summary>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucunu DataResult tipinde geriye döner.</returns>        
        Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActiveAsync();
        /// <summary>
        /// Silinmiş olan tüm kategorileri çeker.
        /// </summary>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucunu DataResult tipinde geriye döner.</returns>
        Task<IDataResult<CategoryListDto>> GetAllByDeletedAsync();
        /// <summary>
        /// Verilen ID parametresine ait kategorinin CategoryUpdateDto temsilini geriye döner.
        /// </summary>
        /// <param name="categoryId">0'dan büyük integer bir ID değeri.</param>
        /// <returns>Asenkron bir operasyon ile Task olarak işlem sonucunu DataResult tipinde geriye döner.</returns>
        Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDtoAsync(int categoryId);
        /// <summary>
        /// Verilen CategoryAddDto ve CreatedByName parametreleri ile birlikte yeni bir Category ekler.
        /// </summary>
        /// <param name="categoryAddDto">categoryAddDto tipinde eklenecek kategori bilgileri.</param>
        /// <param name="createdByName">string tipinde bir değer alır.</param>
        /// <returns>Asenkron bir operasyon ile Task olarak işlemin sonucunu DataResult tipinde döner.</returns>
        Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto categoryAddDto, string createdByName);
        /// <summary>
        /// Verilen CategoryUpdateDto ve modifiedByName parametreleri ile birlikte seçili kategoriyi günceller.
        /// </summary>
        /// <param name="categoryUpdateDto">CategoryUpdateDto tipinde bir değer alır.</param>
        /// <param name="modifiedByName">string tipinde bir değer alır</param>
        /// <returns>Asenkron bir operasyon ile Task olarak işlemin sonucunu DataResult tipinde döner.</returns>
        Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        /// <summary>
        /// CategoryId parametresi ile nesnenin IsDeleted özelliğini true olarak işaretler. Veriyi biz tamamen silene kadar veritabanında tutar.
        /// </summary>
        /// <param name="categoryId">0'dan büyük bir integer ID değeri.</param>
        /// <param name="modifiedByName">string tipinde bir değer alır</param>
        /// <returns>Asenkron bir operasyon ile Task olarak işlemin sonucunu DataResult tipinde döner.</returns>
        Task<IDataResult<CategoryDto>> DeleteAsync(int categoryId, string modifiedByName);
        /// <summary>
        /// CategoryId parametresine ait silinmiş verileri geri getirir.
        /// </summary>
        /// <param name="categoryId">0'dan büyük bir integer ID değeri.</param>
        /// <param name="modifiedByName">string tipinde bir değer alır</param>
        /// <returns>Asenkron bir operasyon ile Task olarak işlemin sonucunu DataResult tipinde döner.</returns>
        Task<IDataResult<CategoryDto>> UndoDeleteAsync(int categoryId, string modifiedByName);
        /// <summary>
        /// CategoryId parametresine ait veriyi veritabanından tamamen siler!
        /// </summary>
        /// <param name="categoryId">0'dan büyük bir integer ID değeri.</param>
        /// <returns></returns>
        Task<IResult> HardDeleteAsync(int categoryId);
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
