using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace DojoDachi.Models
{
    public class Dachi
    {
        public int Happiness {get; set;}
        public int Fullness {get; set;}
        public int Energy {get; set;}
        public int Meals {get; set;}
        public Dachi()
        {
            // 20 happiness, 20 fullness, 50 energy, and 3 meals.
            Happiness = 20;
            Fullness = 20;
            Energy = 50;
            Meals = 3;
        }
        public Dachi UpdateDachi(string dachi_action)
        {
            Random Rand = new Random();
            // Your Dojodachi should start with 20 happiness, 20 fullness, 50 energy, and 3 meals.
            // After every button press, display a message showing how the Dojodachi reacted

            Random Choice = new Random();
            int randChoice;
            int randNum;
            switch(dachi_action)
            {
            // Every time you play with or feed your dojodachi there should be a 25% chance that it won't like it. Energy or meals will still decrease, but happiness and fullness won't change.
                case "feed":
            // Feeding your Dojodachi costs 1 meal and gains a random amount of fullness between 5 and 10 (you cannot feed your Dojodachi if you do not have meals)
                    if(this.Meals > 0)
                    {
                        randChoice = Choice.Next(1,5);
                        if(randChoice != 4)
                        {
                            // dachi does like the food
                            randNum = Rand.Next(5, 11);
                            this.Fullness += randNum;
                        }
                        this.Meals -= 1;
                    }
                    break;
                case "play":
            // Playing with your Dojodachi costs 5 energy and gains a random amount of happiness between 5 and 10
                    randChoice = Choice.Next(1,5);
                        if(randChoice != 4)
                        {
                            // dachi does want to play
                            randNum = Rand.Next(5, 11);
                            this.Happiness += randNum;
                        }
                    this.Energy -= 5;
                    break;
                case "work":
            // Working costs 5 energy and earns between 1 and 3 meals
                    this.Energy -= 5;
                    randNum = Rand.Next(1,4);
                    this.Meals += randNum;
                    break;
                case "sleep":
            // Sleeping earns 15 energy and decreases fullness and happiness each by 5
                    this.Energy += 15;
                    this.Fullness -= 5;
                    this.Happiness -= 5;
                    break;
                default:
                     break;
            }
           
            return this;
        }
    }

    // Somewhere in your namespace, outside other classes
    public static class SessionExtensions
    {
        // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // This helper function simply serializes theobject to JSON and stores it as a string in session
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        
        // generic type T is a stand-in indicating that we need to specify the type on retrieval
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            // Upon retrieval the object is deserialized based on the type we specified
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}