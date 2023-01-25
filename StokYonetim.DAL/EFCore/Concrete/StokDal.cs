using StokYonetim.DAL.Abstract;
using StokYonetim.DAL.EFCore.Context;
using StokYonetim.Entites;

namespace StokYonetim.DAL.EFCore.Concrete
{
    public class StokDal : RepositoryBase<Stok>, IStokDal
    {
        private readonly StokYonetimDbContext dbContext;

        public StokDal(StokYonetimDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
