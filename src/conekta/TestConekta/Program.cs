using System;
using conekta;

namespace TestConekta
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			Api.version = "2.0.0";

			conekta.Api.apiKey = "key_ApncwmaVQszwZf1Hy2kt9g";

			try
			{
				conekta.Customer customer = new conekta.Customer();
				customer.name = "Diana Enriquez";
				customer.email = "diana@conekta.com";
				customer.phone = "5218181818";
				customer.payment_sources = new conekta.PaymentSource[]{
					new conekta.PaymentSource(){
						type="card",
						token_id= "tok_test_visa_4242"
					}
				};

				customer = customer.create(customer.toJSON());
				Console.WriteLine(customer.toJSON());
			}
			catch (Exception ex)
			{
				Console.Write(ex.Message.ToString());
			}
			try
			{
				conekta.Order order = new Order().create(@"{
				          ""currency"": ""MXN"",
				          ""line_items"": [{
				               ""name"": ""ejemplo"",
				               ""unit_price"": 3000,
				               ""quantity"": 1
				          }],
				          ""customer_info"": {
				      ""customer_id"": ""cus_2g9kjsnGFiEpbEFyv""
				 			 },
				          ""charges"": [{
						    ""payment_method"": {
						      ""type"": ""default""
						    }
				  }]
				}");
				Console.Write(order.toJSON());
			}
			catch (Exception ex)
			{
				Console.Write(ex.Message.ToString());
			}
		}
	}
}
