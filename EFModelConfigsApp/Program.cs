using EFModelConfigsApp;

using (EmployeeAppContext context = new EmployeeAppContext())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}