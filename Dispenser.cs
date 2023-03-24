using System;

public class Dispenser
{

	public Dictionary<String, int> chocolates = new Dictionary<string, int>();
    public Stack<Dictionary<String, int>> dispenser_chocolates = new Stack<Dictionary<String, int>>();
    public int totalChocolates;
	public Dispenser()
	{
		this.chocolates["green"] = 10;
        this.chocolates["silver"] = 10;
        this.chocolates["blue"] = 10;
        this.chocolates["crimson"] = 10;
        this.chocolates["purple"] = 10;
        this.chocolates["red"] = 10;
        this.chocolates["pink"] = 10;
        this.totalChocolates = 70;
    }


}
