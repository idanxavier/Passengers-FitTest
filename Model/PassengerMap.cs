using CsvHelper.Configuration;

namespace Model
{
    public class PassengerMap : ClassMap<Passenger>
    {
        public PassengerMap()
        {
            Map(m => m.PassengerId).Index(0);
            Map(m => m.Survived).Index(1);
            Map(m => m.Pclass).Index(2);
            Map(m => m.Name).Index(3);
            Map(m => m.Sex).Index(4);
            Map(m => m.Age).Index(5);
            Map(m => m.SibSp).Index(6);
            Map(m => m.Parch).Index(7);
            Map(m => m.Ticket).Index(8);
            Map(m => m.Fare).Index(9);
            Map(m => m.Cabin).Index(10);
            Map(m => m.Embarked).Index(11);
        }
    }
}