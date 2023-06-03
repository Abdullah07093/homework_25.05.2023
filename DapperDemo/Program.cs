var teacherService = new TeacherService();
var quotes = new Infrastructure.Services.QuoteService();


var teacher = new TeacherDto()
{
    FirstName = "Abdullah",
    LastName = "Abdullah",
    Email = "Abdullah@test",
};


Count();
// Add(teacher);
// Show(null);
void Show(string name)
{
    var teachers = teacherService.GetTeachers(name);
    Console.WriteLine("Id-----------FirstName------------LastName-------------Email");
    foreach (var teacher in teachers)
    {
        Console.WriteLine($"{teacher.Id}-----------{teacher.FirstName}------------{teacher.LastName}-------------{teacher.Email}");
    }
}


void MostPopular(int a)
{
    var quotess = quotes.MostPopularAuthors(a);
    Console.WriteLine("Id-----------FirstName------------LastName-------------Email");
    foreach (var quotes in quotess)
    {
        Console.WriteLine($"{quotes.Id}------------{quotes.Autor}-------------{quotes.QuoteText}---------{quotes.CategoryId}");
    }
}


void GetById(int id)
{
    var teacher = teacherService.GetTeacherById(id);
    Console.WriteLine($"{teacher.Id}");
    Console.WriteLine($"{teacher.FirstName}");
}

void Add(TeacherDto teacher)
{
    var result = teacherService.AddTeacher(teacher);
    Console.WriteLine(result.Id);
}

void Count()
{
    Console.WriteLine(teacherService.CountTeachers());
}