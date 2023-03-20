using Drilling.Infrastructure.Entities;

namespace Drilling.Infrastructure
{
    public class TestData
    {
        public static async Task CreateDataAsync(DrillingContext drillingContext)
        {
            drillingContext.Database.EnsureCreated();
            var drillBlock = new DrillBlock(Guid.NewGuid(), "корректный блок c 3 точками", DateTime.Now);
            if (!drillingContext.DrillBlocks.Any())
            {
                await drillingContext.DrillBlocks.AddAsync(drillBlock);
                await drillingContext.SaveChangesAsync();
            }

            if (!drillingContext.DrillBlockPoints.Any())
            {
                List<DrillBlockPoint> pointsList = new List<DrillBlockPoint> {
                 new DrillBlockPoint(Guid.NewGuid(), drillBlock, 1, 60.787837467040795, 56.91902798264443, 987456.54),
                 new DrillBlockPoint(Guid.NewGuid(), drillBlock, 2, 60.80569025024389, 56.8562598957136, 987456.54),
                 new DrillBlockPoint(Guid.NewGuid(), drillBlock, 3, 60.98971124633765, 56.91639911021044, 987456.54),
            };
                foreach (var point in pointsList)
                    await drillingContext.DrillBlockPoints.AddAsync(point);
                await drillingContext.SaveChangesAsync();
            }

            var hole = new Hole(Guid.NewGuid(), "Корректная скважина", drillBlock, 100);
            if (!drillingContext.Holes.Any())
            {
                await drillingContext.Holes.AddAsync(hole);
                await drillingContext.SaveChangesAsync();
            }

            if (!drillingContext.HolePoints.Any())
            {
                var holePoint = new HolePoint(Guid.NewGuid(), hole, 60.81627351098174, 56.86985763431892, 78945.12345);
                await drillingContext.HolePoints.AddAsync(holePoint);
                await drillingContext.SaveChangesAsync();
            }
        }
    }
}
