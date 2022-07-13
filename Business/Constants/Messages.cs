using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ItemAdded = "Öğe eklendi";
        public static string ItemNameInvaild = "Öğe ismi veya açıklaması geçersiz";
        public static string ItemDeleted = "Öğe silindi";
        public static string ItemUpdated = "Öğe güncellendi";
        public static string ItemListed = "Öğe listelendi";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarNotReturned = "Araç henüz iade edilmemiş";
        public static string EmptyItem = "Öğe sistemde mevcut değil";
        public static string CarCountOfCategoryError = "Bu renk kategorisinde maksimum limite ulaşılmış";

        public static string BrandNameAlreadyExits { get; internal set; }
    }
}
