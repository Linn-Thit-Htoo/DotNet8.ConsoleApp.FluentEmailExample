var serviceCollection = new ServiceCollection();

var fromEmail = "fromEmail@gmail.com";
var toEmail = "toEmail@gmail.com";

Console.Write("Subject : ");
string subject = Console.ReadLine()!;

Console.Write("Body : ");
string body = Console.ReadLine()!;

serviceCollection.AddFluentEmail(fromEmail).AddSmtpSender("smtp.gmail.com", 587, fromEmail, "");

var services = serviceCollection.BuildServiceProvider();

var _fluentEmail = services.GetRequiredService<IFluentEmail>();

var response = await _fluentEmail.To(toEmail).Subject(subject).Body(body).SendAsync();

Console.WriteLine("Message was sent => " + response.Successful);
Console.ReadLine();
