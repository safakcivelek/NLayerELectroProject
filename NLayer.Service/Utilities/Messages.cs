namespace NLayer.Service.Utilities
{
    // Succes veya Error gibi dönüş mesajları için.
    public static class Messages
    {
        // Messages.Category.NotFound()
        // isPlural => Burada örneğin bir AllCategories sonucunda yani çoğul bir durumdaki mesajım ve tek bir Category olması durumundaki tekil mesajımı dönüyorum.(bool)

        // For Category
        public static class Category
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir kategori bulunamadı.";
                return "Böyle bir kategori bulunamadı.";
            }

            public static string Add(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla eklenmiştir.";
            }

            public static string Update(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla güncellenmiştir.";
            }

            public static string Delete(string categoryName)
            {
                return $"{categoryName} adlı kategori başarıyla silinmiştir.";
            }

            public static string HardDelete(string categoryName)
            {
                return $"(\"{categoryName}\") adlı kategori, başarıyla kalıcı olarak silinmiştir.";
            }

            public static string UndoDelete(string categoryName)
            {
                return $"(\"{categoryName}\") adlı kategori, başarıyla arşivden geri getirilmiştir.";
            }
        }

        // For Product
        // Eklenecek Mesaj=> Warning:Lütfen, listeye ürün ekleyin.( 0 adet sonuç dönme durumu için!) 
        public static class Product
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir ürün bulunamadı.";
                return "Böyle bir ürün bulunamadı.";
            }
            public static string Add(string productName)
            {
                return $"{productName} adlı ürün başarıyla eklenmiştir.";
            }
            public static string Update(string productName)
            {
                return $"{productName} adlı ürün başarıyla güncellenmiştir.";
            }
            public static string Delete(string productName)
            {
                return $"{productName} adlı ürün başarıyla silinmiştir.";
            }
            public static string HardDelete(string productName)
            {
                return $"(\"{productName}\") adlı ürün, başarıyla kalıcı olarak silinmiştir.";
            }

            public static string UndoDelete(string productName)
            {
                return $"(\"{productName}\") adlı ürün, başarıyla arşivden geri getirilmiştir.";
            }
        }

        // For Order
        public static class Order
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir sipariş bulunamadı.";
                return "Böyle bir sipariş bulunamadı.";
            }
            public static string Approve(int orderId)
            {
                return $"Sayın {orderId} ID'li sipariş başarıyla onaylanmıştır.";
            }
            public static string Add(string orderName)
            {
                return $"{orderName} adlı sipariş başarıyla eklenmiştir.";
            }
            public static string Update(int orderId)
            {
                return $"{orderId} ID'li sipariş başarıyla güncellenmiştir.";
            }
            public static string Delete(int orderId)
            {
                return $"{orderId} ID'li sipariş başarıyla silinmiştir..";
            }
            public static string HardDelete(int orderId)
            {
                return $"(\"{orderId}\") ID'li sipariş, başarıyla kalıcı olarak silinmiştir.";
            }
            public static string UndoDelete(int orderId)
            {
                return $"(\"{orderId}\") ID'li sipariş, başarıyla arşivden geri getirilmiştir.";
            }
        }
        // For Comment
        public static class Comment
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiç bir yorum bulunamadı.";
                return "Böyle bir yorum bulunamadı.";
            }

            public static string Approve(int commentId)
            {
                return $"Sayın {commentId} no'lu yorum başarıyla onaylanmıştır.";
            }

            public static string Add(string createdByName)
            {
                return $"Sayın {createdByName}, yorumunuz başarıyla eklenmiştir.";
            }

            public static string Update(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla güncellenmiştir.";
            }
            public static string Delete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla silinmiştir.";
            }
            public static string HardDelete(string createdByName)
            {
                return $"{createdByName} tarafından eklenen yorum başarıyla kalıcı olarak silinmiştir.";
            }

            public static string UndoDelete(string createdByName)
            {
                return $"(\"{createdByName}\") tarafından eklenen yorum başarıyla arşivden geri getirilmiştir.";
            }
        }
    }
}
