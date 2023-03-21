
var people = new Person[]
{
    new Person("Tom"),
    new Person("Bob"),
    new Person("Sam")
};
var xsoft = new Company(people); 

foreach (Person employee in xsoft.GetPersonnel(5)) // five vs three Person objects to show how yield break works

{
    Console.WriteLine(employee.Name);
}

Console.ReadKey();

class Person
{
    public string Name { get; }
    public Person(string name) => Name = name;
}
class Company
{
    public Person[] personnel;
    public Company(Person[] personnel) => this.personnel = personnel;
    public IEnumerable<Person> GetPersonnel(int max) 
    {
        for (int i = 0; i < max; i++)
        {
            if (i == personnel.Length)
            {
                yield break; // used to end iteration (after 3)
            }
            else
            {
                yield return personnel[i]; // return one element at a time
            }
        }
    }
}