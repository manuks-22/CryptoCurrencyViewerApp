## Answers to technical question

1. The time spent on the assignment was around 20 hours. 
Provided there is more time available, I would like to spend time on the following items.
- Have separate project for .Net core API and the Razor.
-   Razor page to have a drop down to select the currecy. This could be populated using the listings api available at https://coinmarketcap.com/api. The text box is always error prone and the current one needs more validations.
-   Introduce rounding off to the exchange values displayed, if that is a requirement.
-   Introduce a generic HttpClientFactory for the razor pages.
-   Overall better unit test coverage. For example, the extension method ***'QueryCollectionToDictionary, Guards'*** are not covered.
-   Introduce Jwt Authentication for API.

2. C# 9.0 records feature is one of the most useful feature that was added. It helps to create light weight immutable types. It also by default supports structural and reference equality. 
##### Code snippet from the assignment.
```
  public record ExchangeRateDto
    {
        /// <summary>
        /// Get the CurrencyId property.
        /// </summary>
        public string CurrencyId { get; init; }

        /// <summary>
        /// Get the Rate property.
        /// </summary>
        public double Rate { get; init; }

        public ExchangeRateDto(string currencyId, double rate)
        {
            CurrencyId = currencyId;
            Rate = rate;
        }
    }
```
#### Code snippet on equality check, not from the assignment
```
        ExchangeRateDto exchangeDto1 = new("BTC", 67d);
        ExchangeRateDto exchangeDto2 = new("BTC", 67d);
        ExchangeRateDto exchangeDtoRef3 = exchangeDto1;

        if(Equals(exchangeDto1, exchangeDto2))
        {
            Console.WriteLine("Structurally equal!!");
        }

        if (ReferenceEquals(exchangeDto1, exchangeDtoRef3))
        {
            Console.WriteLine("References are equal!!");
        }
```

3. I have not debugged performance issue in production environment. But rather have worked with identifying performance issues in desktop based applications using Visual studio performance tools.

4. One of the recent books that I read which turned out interesting was  ***CLR via C# by Jeffery Richter***. It provides an indepth visualization of how C# works internally.
Morover, I follow Udemy courses. Currently pursuing the course ***Ultimate AWS Certified Developer Associate 2022***.

5. The technical assesment was very interesting. The statement is one, that can be easily related by a developer. It was good to work on a real life scenario rather than, solving hypothetical scenarios and algorithms like that of many other interview processes. The options to choose the technology and architecture was thought provoking.

6. About me.
```json
{
  "name": "Manu",
  "middlename": "Kochuparambil",
  "lastname": "Sasidharan",
  "age": 38,
  "nationality": "Indian",
  "residing": "India",
  "city": "Cochin",
  "maritalstatus": "Married",
  "hobbies": [
    "Gaming",
    "RoadTrips",
    "Movies"
  ],
  "aboutmyself": [
    "I am quick learner and an astute problem solver. I get things done. As a newbie to an AWS migration team without any prior AWS experience, I could quickly pickup Infrasturcture as code using Cloud Formation and became the single point of contact for the infrastructure and the deployment pipeline creation. I am also self organised with track record of leading teams on technical and delivery front. On the personal front, I am married and have two energetic young boys, who keep me on my toes during my time off from work. Though living a hectic schedule, I still find time to pursue my passion to travel, especially roadtrips. One of the recent trips was a 7000 kilometer road trip to Rajasthan travelling across 7 states in India."
  ] 
}
```  
