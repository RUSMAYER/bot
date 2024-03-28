using Telegram.Bot.Polling;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        var client = new TelegramBotClient("6877543441:AAE5bOZdA9ZYMiRJKz0PLGJsZzQci1cJzrA");
        client.StartReceiving(UpdateHandler, Error); /*метод, который выводит бот*/
        Console.ReadLine();
    }
    private static async Task MessageHeandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        switch (update.Type)
        {
            case UpdateType.Message:
                {
                    var message = update.Message;
                    var user = message.From;
                    var chat = message.Chat;

                    switch (message.Type)
                    {
                        case MessageType.Text:
                            {
                                if (message.Text == null)
                                {
                                    return;

                                }
                                if (message.Text == "/start")
                                {
                                    //создание кнопок в строке
                                    InlineKeyboardMarkup inlineKeyboard = (new[]
                                    {
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "Камень", callbackData: "Камень"),
                                        },
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "Ножницы", callbackData: "Ножницы"),
                                        },
                                        new []
                                        {
                                            InlineKeyboardButton.WithCallbackData(text: "Бумага", callbackData: "Бумага"),
                                        },
                                        });

                                    Message sentMessage = await botClient.SendTextMessageAsync(
                                        chatId: chat.Id,
                                        text: "Выберите 'Камень', 'Ножницы', 'Бумага' : ",
                                        replyMarkup: inlineKeyboard,
                                        cancellationToken: cancellationToken) ;

                                    return;
                                }
                                return;
                            }
                    }
                    return;
                }
        }

    }
    private static async Task CallBack(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        Random rnd = new Random();
        int min = 1, max = 3;
        int randomnamber=rnd.Next(min, max);
        //вывод в зависимости от выбранной кнопки
        //1-Камень,2-Ножницы,3-Бумага
        if (update != null && update.CallbackQuery != null)
        {
            string answer = update.CallbackQuery.Data;
            switch (answer)
            {
                case "Камень":
                    Message message = await botClient.SendPhotoAsync(
                    chatId: update.CallbackQuery.Message.Chat.Id,
                     photo: InputFile.FromUri("https://vsegda-pomnim.com/uploads/posts/2023-03/1678960949_vsegda-pomnim-com-p-foto-kamnya-png-26.jpg"),
                    caption: "<b>Камень</b>. ",
                    parseMode: ParseMode.Html,
                     cancellationToken: cancellationToken);
                    await botClient.SendTextMessageAsync(
                     chatId: update.CallbackQuery.Message.Chat.Id,
                     text: "Вы выбрали Камень!",
                     cancellationToken: cancellationToken);
                    await botClient.SendTextMessageAsync(
                     chatId: update.CallbackQuery.Message.Chat.Id,
                     text: "Бот выбирает...",
                     cancellationToken: cancellationToken);
                    if (randomnamber == 1)
                    {
                       await botClient.SendTextMessageAsync(
                     chatId: update.CallbackQuery.Message.Chat.Id,
                     text: "Бот тоже выбрал Камень!\nНичья!",
                     cancellationToken: cancellationToken);
                         await botClient.SendPhotoAsync(
                    chatId: update.CallbackQuery.Message.Chat.Id,
                     photo: InputFile.FromUri("https://avatars.dzeninfra.ru/get-zen_doc/271828/pub_6566e980bfa8910d18f6a3a2_6566eb7af22ca056484bc34b/scale_1200"),
                    caption: "<b>Ничья!</b>. ",
                    parseMode: ParseMode.Html,
                     cancellationToken: cancellationToken);
                    }
                    if(randomnamber == 2)
                    {
                        await botClient.SendTextMessageAsync(
                     chatId: update.CallbackQuery.Message.Chat.Id,
                     text: "Бот выбрал ножницы!\nТы победил!!!",
                     cancellationToken: cancellationToken);
                        await botClient.SendPhotoAsync(
                   chatId: update.CallbackQuery.Message.Chat.Id,
                    photo: InputFile.FromUri("https://belon.club/uploads/posts/2023-04/1681409295_belon-club-p-radostnii-muzhik-pinterest-3.jpg"),
                   caption: "<b>Победа!</b>. ",
                   parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
                    }
                    if (randomnamber == 3)
                    {
                        await botClient.SendTextMessageAsync(
                     chatId: update.CallbackQuery.Message.Chat.Id,
                     text: "Бот выбрал бумагу!\nТы проиграл!",
                     cancellationToken: cancellationToken);
                        await botClient.SendPhotoAsync(
                   chatId: update.CallbackQuery.Message.Chat.Id,
                    photo: InputFile.FromUri("https://mykaleidoscope.ru/x/uploads/posts/2022-09/1663586830_14-mykaleidoscope-ru-p-toska-bez-kontsa-vkontakte-15.jpg"),
                   caption: "<b>Повезет в другой раз!</b>. ",
                   parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
                        
                    }
                    break;
                case "Ножницы":
                    await botClient.SendPhotoAsync(
                    chatId: update.CallbackQuery.Message.Chat.Id,
                     photo: InputFile.FromUri("https://cdn1.ozone.ru/s3/multimedia-5/6709777025.jpg"),
                    caption: "<b>Ножницы</b>. ",
                    parseMode: ParseMode.Html,
                     cancellationToken: cancellationToken);
                    await botClient.SendTextMessageAsync(
                     chatId: update.CallbackQuery.Message.Chat.Id,
                     text: "Вы выбрали Ножницы!",
                     cancellationToken: cancellationToken);
                    await botClient.SendTextMessageAsync(
                     chatId: update.CallbackQuery.Message.Chat.Id,
                     text: "Бот выбирает...",
                     cancellationToken: cancellationToken);
                    if (randomnamber == 1)
                    {
                        await botClient.SendTextMessageAsync(
                     chatId: update.CallbackQuery.Message.Chat.Id,
                     text: "Бот выбрал камень!\n Ты проиграл!",
                     cancellationToken: cancellationToken);
                        await botClient.SendPhotoAsync(
                   chatId: update.CallbackQuery.Message.Chat.Id,
                    photo: InputFile.FromUri("https://mykaleidoscope.ru/x/uploads/posts/2022-09/1663586830_14-mykaleidoscope-ru-p-toska-bez-kontsa-vkontakte-15.jpg"),
                   caption: "<b>Повезет в другой раз!</b>. ",
                   parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
                    }
                    if (randomnamber == 2)
                    {
                        await botClient.SendTextMessageAsync(
                     chatId: update.CallbackQuery.Message.Chat.Id,
                     text: "Бот тоже выбрал ножницы!\nНичья!",
                     cancellationToken: cancellationToken);
                        await botClient.SendPhotoAsync(
                   chatId: update.CallbackQuery.Message.Chat.Id,
                    photo: InputFile.FromUri("https://avatars.dzeninfra.ru/get-zen_doc/271828/pub_6566e980bfa8910d18f6a3a2_6566eb7af22ca056484bc34b/scale_1200"),
                   caption: "<b>Ничья!</b>. ",
                   parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
                    }
                    if (randomnamber == 3)
                    {
                        await botClient.SendTextMessageAsync(
                     chatId: update.CallbackQuery.Message.Chat.Id,
                     text: "Бот выбрал бумагу!\nТы выиграл!!!",
                     cancellationToken: cancellationToken);
                        await botClient.SendPhotoAsync(
                   chatId: update.CallbackQuery.Message.Chat.Id,
                    photo: InputFile.FromUri("https://belon.club/uploads/posts/2023-04/1681409295_belon-club-p-radostnii-muzhik-pinterest-3.jpg"),
                   caption: "<b>Победа!</b>. ",
                   parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
                        
                    }
                    break;

                case "Бумага":
                    await botClient.SendPhotoAsync(
                   chatId: update.CallbackQuery.Message.Chat.Id,
                    photo: InputFile.FromUri("https://cdn1.ozone.ru/s3/multimedia-8/6647042744.jpg"),
                   caption: "<b>Бумага</b>. ",
                   parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
                    await botClient.SendTextMessageAsync(
                     chatId: update.CallbackQuery.Message.Chat.Id,
                     text: "Вы выбрали Бумагу!",
                     cancellationToken: cancellationToken);
                    await botClient.SendTextMessageAsync(
                     chatId: update.CallbackQuery.Message.Chat.Id,
                     text: "Бот выбирает...",
                     cancellationToken: cancellationToken);
                    if (randomnamber == 1)
                    {
                        await botClient.SendTextMessageAsync(
                     chatId: update.CallbackQuery.Message.Chat.Id,
                     text: "Бот выбрал камень!\nТы выиграл!!!",
                     cancellationToken: cancellationToken);
                        await botClient.SendPhotoAsync(
                   chatId: update.CallbackQuery.Message.Chat.Id,
                    photo: InputFile.FromUri("https://belon.club/uploads/posts/2023-04/1681409295_belon-club-p-radostnii-muzhik-pinterest-3.jpg"),
                   caption: "<b>Победа!</b>. ",
                   parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
                    }
                    if (randomnamber == 2)
                    {
                        await botClient.SendTextMessageAsync(
                     chatId: update.CallbackQuery.Message.Chat.Id,
                     text: "Бот выбрал ножницы!\nТы проиграл!",
                     cancellationToken: cancellationToken);
                        await botClient.SendPhotoAsync(
                   chatId: update.CallbackQuery.Message.Chat.Id,
                    photo: InputFile.FromUri("https://mykaleidoscope.ru/x/uploads/posts/2022-09/1663586830_14-mykaleidoscope-ru-p-toska-bez-kontsa-vkontakte-15.jpg"),
                   caption: "<b>Повезет в другой раз!</b>. ",
                   parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
                    }
                    if (randomnamber == 3)
                    {
                        await botClient.SendTextMessageAsync(
                     chatId: update.CallbackQuery.Message.Chat.Id,
                     text: "Бот тоже выбрал бумагу!\nНичья!",
                     cancellationToken: cancellationToken);
                        await botClient.SendPhotoAsync(
                   chatId: update.CallbackQuery.Message.Chat.Id,
                    photo: InputFile.FromUri("https://avatars.dzeninfra.ru/get-zen_doc/271828/pub_6566e980bfa8910d18f6a3a2_6566eb7af22ca056484bc34b/scale_1200"),
                   caption: "<b>Ничья!</b>. ",
                   parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
                        
                    }
                    break;

            }


            //InlineKeyboardMarkup inlineKeyboard = update.CallbackQuery.Message.ReplyMarkup!;
            //var inlines = inlineKeyboard.InlineKeyboard;
            //foreach (var item1 in inlines)
            //{
            //    foreach (var item2 in item1)
            //    {

            //       
            //    }
            //}
        }
    }

    private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
    {
        throw new NotImplementedException();
    }
    private static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        await CallBack(botClient, update, cancellationToken);
        await MessageHeandler(botClient, update, cancellationToken);

    }
}