using Core.Abstracts.Bases;
using Core.Concretes.Models;
using Core.Utils;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Data
{
    /// <summary>
    /// Unit of Work pattern'ını uygulayan sınıf.
    /// Veritabanı işlemlerinin merkezi koordinasyon noktası olarak görev yapar.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        // Veritabanı bağlamı - Entity Framework tarafından sağlanan DbContext örneği
        private readonly AppDbContext context;

        /// <summary>
        /// UnitOfWork yapıcısı. DbContext'i dependency injection yoluyla alır.
        /// </summary>
        /// <param name="context">Entity Framework veritabanı bağlamı</param>
        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Veritabanıda yapılan tüm değişiklikleri kaydeder.
        /// Başarı veya hata durumunda bir Reply nesnesi döndürür.
        /// </summary>
        /// <returns>İşlem sonucu (başarı/başarısızlık bilgisi)</returns>
        public async Task<Reply> CommitAsync()
        {
            try
            {
                // Tüm değişiklikleri veritabanına asenkron olarak kaydet
                int rows = await context.SaveChangesAsync();
                // Başarılı işlem sonucunu döndür
                return Reply.Success();
            }
            catch (Exception ex)
            {
                // Hata durumunda hata mesajı ile başarısız sonuç döndür
                return Reply.Fail(ex.Message);
            }
        }

        /// <summary>
        /// DbContext kaynağını asenkron olarak serbest bırakır.
        /// Veritabanı bağlantısını kapatır ve belleği temizler.
        /// </summary>
        public async ValueTask DisposeAsync() => await context.DisposeAsync();

        // Repository nesnelerini cache'lemek için Hashtable koleksiyonu.
        // Her entity türü için bir kez repository oluşturulur ve saklanır.
        private Hashtable? repositories;

        /// <summary>
        /// Verilen entity türü için repository örneği alır veya oluşturur.
        /// Repository'ler cache'lendiği için aynı türe erişim performant'tır.
        /// </summary>
        /// <typeparam name="T">Entity sınıfı (BaseEntity'den türemiş olmalı)</typeparam>
        /// <returns>İstenen entity türü için repository örneği</returns>
        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            // Eğer repository cache'i yoksa, yeni bir Hashtable oluştur
            repositories ??= [];

            // Entity türünün adını al (cache key'i olarak kullanacağız)
            string type = typeof(T).Name;

            // Eğer bu türün repository'si daha önce oluşturulmamışsa
            if (!repositories.ContainsKey(type))
            {
                // Generic Repository sınıfının tanımını al
                var repoType = typeof(Repository<>);

                // Repository<T> türünü dinamik olarak oluştur ve DbContext'i geç
                var repoInstance = Activator.CreateInstance(repoType.MakeGenericType(typeof(T)), context);

                // Oluşturulan repository'i cache'e ekle
                repositories.Add(type, repoInstance);
            }

            // Cache'ten repository'yi al ve döndür
            return (IRepository<T>)repositories[type]!;
        }
    }
}