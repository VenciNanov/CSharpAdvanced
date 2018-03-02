public interface IAnimal
    {
    string Name { get; set; }
    double Weight { get; set; }
    int FoodEaten { get; set; }

    void MakeSound();
    void Eat(Food food);
}
