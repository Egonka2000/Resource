using Resources.Data;

namespace Resources.Business
{
    public class Service : IService
    {
        protected ResourceDbContext Ctx;
        public Service(ResourceDbContext ctx)
        {
                this.Ctx = ctx;
        }

        public (string, int) UseResource()
        {
            var resource = Ctx.Resources.Where(x => x.ResourceUsages.Count < x.MaximumUsages).FirstOrDefault();

            if (resource == null)
            {
                Resource res = new Resource() { MaximumUsages = 3 };
                ResourceUsage usage = new ResourceUsage() { ResourceName = res.UniqueName, Usage = DateTime.Now };

                this.Ctx.ResourceUsages.Add(usage);

                res.ResourceUsages.Add(usage);

                this.Ctx.Resources.Add(res);
                this.Ctx.SaveChanges();

                return (res.UniqueName, res.MaximumUsages - res.ResourceUsages.Count);
            }
            else
            {
                ResourceUsage usage = new ResourceUsage() { ResourceName = resource.UniqueName, Usage = DateTime.Now };

                this.Ctx.ResourceUsages.Add(usage);

                resource.ResourceUsages.Add(usage);

                this.Ctx.SaveChanges();

                return (resource.UniqueName, resource.MaximumUsages - resource.ResourceUsages.Count);
            }
        }
    }
}
