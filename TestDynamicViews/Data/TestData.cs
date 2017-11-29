using System.Collections.Generic;

namespace TestDynamicViews.Data
{
    public static class TestData
    {
        public static readonly IEnumerable<DynamicView> DynamicViews = new HashSet<DynamicView>
        {
            new DynamicView { Path = "/Views/Home/Index2.cshtml", Content = @"
@model IEnumerable<TestDynamicViews.Data.Employee>
@{
    Layout = null;
    ViewBag.Title = ""List of Employees"";
}
<!DOCTYPE html>
<html>
<head>
    <title>@ViewBag.Title</title>
</head>
<body>
    <h1>List of Employees</h1>
    <h2>Yo, this view is the first dynamic view!</h2>
    <table>
        <thead>
            <tr>
                <th>Id</th>
                <th>First Name</th>
                <th>Last Name</th>
            </tr>
        </thead>
        <tbody>
            @foreach(var item in Model)
            {
                <tr>
                    <td>@item.Id</td>
                    <td>@item.FirstName</td>
                    <td>@item.LastName</td>
                </tr>
            }
        </tbody>
    </table>
</body>
</html>
            " },
            new DynamicView { Path = "/Views/Home/Index3.cshtml", Content = @"
@model IEnumerable<TestDynamicViews.Data.Employee>
@{
    Layout = null;
    ViewBag.Title = ""List of Employees"";
}
<!DOCTYPE html>
<html>
<head>
    <title>@ViewBag.Title</title>
</head>
<body>
    <h1>List of Employees</h1>
    <h2>This, my good man, is the second dynamic view.</h2>
    <table border=""1"" cellpadding=""5"">
        <thead>
            <tr>
                <th>Id</th>
                <th>First Name</th>
                <th>Last Name</th>
            </tr>
        </thead>
        <tbody>
            @foreach(var item in Model)
            {
                <tr>
                    <td>@item.Id</td>
                    <td>@item.FirstName</td>
                    <td>@item.LastName</td>
                </tr>
            }
        </tbody>
    </table>
</body>
</html>
            " }
        };

        public static readonly IEnumerable<Employee> Employees = new HashSet<Employee>
        {
            new Employee { Id = 1, FirstName = "Nancy", LastName = "Davolio" },
            new Employee { Id = 2, FirstName = "Andrew", LastName = "Fuller" },
            new Employee { Id = 3, FirstName = "Janet", LastName = "Leverling" },
            new Employee { Id = 4, FirstName = "Margaret", LastName = "Peacock" },
            new Employee { Id = 5, FirstName = "Steven", LastName = "Buchanan" },
            new Employee { Id = 6, FirstName = "Michael", LastName = "Suyama" },
        };
    }

    public class DynamicView
    {
        public string Path { get; set; }
        public string Content { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}