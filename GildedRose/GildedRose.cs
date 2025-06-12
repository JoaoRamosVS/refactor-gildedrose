using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;
    private const string AgedBrie = "Aged Brie";
    private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
    private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
    private const string Conjured = "Conjured Mana Cake";
    private const int MinQuality = 0;
    private const int MaxQuality = 50;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach (var item in Items) {
            
            if (item.Name == Sulfuras)
            {
                continue;
            }

            item.SellIn--;

            if (item.Name == AgedBrie)
            {
                if (item.Quality < MaxQuality)
                {
                    item.Quality++;
                }
            }
            else if (item.Name == BackstagePasses)
            {
                if (item.SellIn < 0)
                {
                    item.Quality = MinQuality;
                }
                else if (item.SellIn < 5 && item.Quality < 48)
                {
                    item.Quality += 3;
                }
                else if (item.SellIn < 10 && item.Quality < 49)
                {
                    item.Quality += 2;
                }
                else if (item.Quality < MaxQuality)
                {
                    item.Quality++;
                }
            }
            else if (item.Name == Conjured)
            {
                if (item.SellIn < 0)
                {
                    if (item.Quality > 4)
                    {
                        item.Quality -= 4;
                    }
                    else
                    {
                        item.Quality = MinQuality;
                    }
                }
                else
                {
                    if (item.Quality > 3)
                    {
                        item.Quality -= 2;
                    }
                    else if (item.Quality > 1)
                    {
                        item.Quality -= 1;
                    }
                    else
                    {
                        item.Quality = MinQuality;
                    }
                }
            }
            else
            {
                if (item.Quality > MinQuality)
                {
                    if (item.SellIn < 0)
                    {
                        if (item.Quality > 1)
                        {
                            item.Quality -= 2;
                        }
                        else
                        {
                            item.Quality = MinQuality;
                        }

                    }
                    else
                    {
                        item.Quality--;
                    }
                }
            }
        }
    }
}