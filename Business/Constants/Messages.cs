using Core.Entities.Concete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Zaman Aşımı";
        public static string ProductsListed = "Ürünler Listelendi";
        public static string ErrorProductsListed = "Ürünler Listelenemedi";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün içerebilir";
        public static string ProductNameAlredyExists="Bu isim zaten başka bir ürün var";
        public static string CategoryLimitExceded="Kategori şimiti aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied="Yetkiniz yok ";
        public static string UserRegistered="Kayıt Oldu";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError="Parola Hatası";
        public static string SuccessfulLogin="Başarılı Giriş";
        public static string UserAlreadyExists="Kullanıcı Mevcut";
        public static string AccessTokenCreated="Token Oluşturuldu";
    }
}