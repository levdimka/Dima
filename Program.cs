using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ТГ_Бот 
{
    class Program 
    {
        static void Main(string[] args)
        {
            var client = new TelegramBotClient("5538169577:AAHuOHfRQZ2ZFN-55AZPIAPmwuoq0aockAY");
            client.StartReceiving(Update,Error);
            Console.ReadLine();
        }

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            if (message.Text == null)
            {
                if (message.Text.ToLower().Contains("привет"))
                  {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "пока");
                    return;
                  }    
            }
            if (message.Photo !=null)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "фотка норм, но лучше отправь документом.");
                return;
            }    

        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }
    }
}