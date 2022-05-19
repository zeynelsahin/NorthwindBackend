using System.Collections.Generic;
using Core.Entities.Concete;
using Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Zaman aşımı";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ErrorProductsListed = "Ürünler listelenemedi";
        public static string ProductNameAlredyExists = "Bu isim zaten başka bir ürün var";
        public static string ProductUpdated = "Ürün güncellendi";
        public static string ProductNotFound = "Ürün bulunamadı";
        public static string ProductDeleted = "Ürün silindi";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün içerebilir";

        public static string CategoryAdded = "Kategori eklendi";
        public static string CategoryUpdated = "Kategori güncellendi";
        public static string CategoryDeleted = "Kategori silindi";
        public static string CategoryListed = "Kategori listelendi";
        public static string CategoryNotFound = "Kategori bulunamadı";
        public static string CategoryLimitExceded = "Kategori şimiti aşıldığı için yeni ürün eklenemiyor";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt oldundu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";

        public static string CustomersListed = "Müşteriler listelendi";
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";

        public static string EmployeeAdded = "Çalışan eklendi";
        public static string EmployeeDeleted = "Çalışan silindi";
        public static string EmployeeUpdated = "Çalışan güncellendi";
        public static string EmployeesListed = "Çalışanlar listelenedi";
        public static string EmployeeCountryNotFound = "Ülke bulunamadı";
        public static string EmployeeNotFound = "Çalışan bulunamadı";
        public static string EmployeeNotExistsForReportsTo = "Rapor için girilen çalışan bulunamadı";

        public static string? OperationClaimsListed = "Operasyon talepleri listelendi";
        public static string OperationClaimAdded = "Operasyon talebi eklendi";
        public static string OperaClaimUpdated = "Operasyon talebi eklendi";
        public static string OperationClaimDeleted = "Operasyon talebi silindi";

        public static string UserOperationClaimsListed = "Kullanıcı operasyon talepleri listelendi";
        public static string UserOperationClaimAdded = "Kullanıcı operasyon talebi eklendi";
        public static string UserOperationClaimDeleted = "Kullanıcı operasyon talebi silindi";
        public static string UserOperationClaimUpdated = "Kullanıcı operasyon talebi güncellendi";
        public static string OperaClaimNotFound = "Operasyon talebi bulunamadı";

        public static string CustomerCityNotFound = "Şehir bulunamadı";
        public static string CustomerPostalCodeNotFound = "Posta kodu bulunamadı";
        public static string EmployeeCityNotFound = "Şehir bulunamadı";
        public static string CustomerListed = "Müşteri listelendi";
        public static string CustomerNotFound = "Müşteri bulunamadı";

        public static string OrderDeleted = "Sipariş silindi";
        public static string OrderNotFound = "Sipariş bulunamadı";
        public static string OrderAdded = "Sipariş eklendi";
        public static string OrderUpdated = "Sipariş güncellendi";
        public static string OrdersListed = "Siparişler listelendi";
        public static string OrderListed = "Sipariş listelendi";
        public static string OrderNotCustomer = "Müşterinin satın aldığı ürün yok";
        public static string OrderNotEmployee = "Çalışanın sattığı ürün yok";
    }
}