using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static  class Messages
    {
        public static string CarAdded = "Araç Eklendi";
        public static string CarDeleted = "Araç Silindi";
        public static string CarUpdated = "Araç Güncellendi";
        public static string MaintenanceTime = "Geçersiz İşlem sistem için bakım zamanı";
        public static string CarsListed = "Araçlar Listelendi";
        
        public static string BrandListed = "Model Listelendi";
        public static string BrandDeleted = "Model Silindi";
        public static string BrandUpdated = "Model Güncellendi";
        public static string BrandAdded = "Model Eklendi";
        
        public static string ColorAdded = "Renk Eklendi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorUpdated = "Renk Güncellendi";
        public static string ColorListed = "Renk Listelendi";
        
        public static string RentalAdded = "Kiralama Eklendi";
        public static string RentalListed = "Kiralama Listelendi";
        public static string RentalDeleted = "Kiralama Silindi";
        public static string RentalUpdated = "Kiralama Güncellendi";
        public static string RentalInvalid = "Kiralama geçersiz";

        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserListed = "Kullanıcı Listelendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string FirstNameInvalid = "Kullanıcı ve Soyadı geçersiz";

        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerListed = "Müşteri Listelendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CompanyNameInvalid = "Şirket adı geçersiz";

        public static string CarImageAdded = "Araba Resmi Eklendi";
        public static string CarImageListed = "Araba Resmi Listelendi";
        public static string CarImageDeleted = "Araba Resmi Silindi";
        public static string CarImageUpdated = "Araba Resmi Güncellendi";

        public static string FailAddedImageLimit { get; internal set; }
        public static string ImagesAdded { get; internal set; }
        public static string CarImageCountError { get; internal set; }
        public static string ClaimsListed { get; internal set; }
    }
}
