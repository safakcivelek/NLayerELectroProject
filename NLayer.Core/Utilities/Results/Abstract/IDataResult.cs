namespace NLayer.Core.Utilities.Results.Abstract
{  
    public interface IDataResult<out T> : IResult
    {
        public T Data { get; }  // new DataResult<Category>(ResultStatus.Success,category);
                                // new DataResult<IList<Category>>(ResultStatus.Success,categoryList);      
    }
    
    // Datayı bu tip içerisinde döneceğim ve generic olarak kullanıcam.   
    // "IDataResult<out T>" =>  T ile out kullandım çünkü gelen T'yi tek başına bir Entity olarak veya bir Liste halinde gönderebileceğim.

    // “ref” anahtar kelimesini genelde bir tane referans verilecek durumlarda, 
    // “out” anahtar kelimesini ise bir metodun birden fazla değeri geri vermesini istediğimiz durumlarda kullanıyoruz.
}
