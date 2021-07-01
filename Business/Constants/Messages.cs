using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün İsmi Geçersiz";
        public static string MaintenanceTime = "Sistem Bakım Zamanı";
        public static string ProductsListed = "Ürünler Listelendi";
        public static string UnitPriceInvalid = "Ürün Fiyatı Geçersiz";
        public static string ProductCounOfCategoryError = "Bir Kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists = "Bu İsimde zaten başka bir ürün var";
        public static string CategoryLimitExceded = "Kategory Limiti Aşıldığı İçin Yeni Ürün Eklenemiyor";
        public static string AuthorizationDenied = "Yetkiniz Yok!";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

    }
}
