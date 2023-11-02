using RequestApplication.Entities;

namespace RequestApplicatioin.DB
{
    public class Initializer
    {
        public static async Task InitializeAsync(IDbRepository<Application> appRepository)
        {
            if (!appRepository.Get().Any())
            {
                await appRepository.AddRange(new List<Application>() 
                {
                    new Application()
                    {
                        Name ="Трекаем время",
                        Description = "Несмотря на свое название, в нем можно трекать время.",
                        Requests = new List<Request>()
                        {
                            new Request()
                            {
                                Name = "Переведите время на московское.",
                                Description = "Невозможно работать.",
                                EndDate = new DateTime(2023,11,1),
                                Email = "MoscowUser@mail.ru",
                            },
                            new Request()
                            {
                                Name = "Переделайте фронт на реакте уже.",
                                Description = "Невозможно работать.",
                                Email = "PickyUser@mail.ru",
                            },
                            new Request()
                            {
                                Name = "Перекрасьте кнопку в зеленый",
                                Description = "Работать возможно, но не сильно хочется.",
                                EndDate = new DateTime(2023,10,30),
                                Email = "ColorblindUser@mail.ru",
                            },
                            new Request()
                            {
                                Name = "Перекрасьте кнопку обратно в серый",
                                Description = "Оказывается серый был лучше...",
                                EndDate = new DateTime(2023,10,31),
                                Email = "ColorblindUser@mail.ru",
                            },
                        }
                    },
                    new Application()
                    {
                        Name ="Skype 2.0",
                        Description = "Мы сами его написали чтобы ходить на созвоны вместо того, чтобы кодить.",
                        Requests = new List<Request>()
                        {
                            new Request()
                            {
                                Name = "Не могу создать конференцию.",
                                Description = "Скрин ошибки отправлю в личку.",
                                EndDate = new DateTime(2023,10,15),
                                Email = "CommunicativeUser@mail.ru",
                            },
                            new Request()
                            {
                                Name = "Хочу создавать конференции на 100 человек",
                                Description = "Это в два раза больше чем сейчас.",
                                EndDate = new DateTime(2023,10,20),
                                Email = "VeryCommunicativeUser@mail.ru",
                            },
                            new Request()
                            {
                                Name = "Не могу найти кнопку завершения созвона, сижу тут уже два дня",
                                Description = "Помогите...",
                                EndDate = new DateTime(2023,10,3),
                                Email = "UnhappyUser@mail.ru",
                            },
                            new Request()
                            {
                                Name = "Поменяйте название на Skype 3.0",
                                Description = "Бог любит троицу.",
                                Email = "HolyUser@mail.ru",
                            },
                        }
                    },
                    new Application()
                    {
                        Name ="Application_01",
                        Description = "Description_01",
                        Requests = new List<Request>()
                        {
                            new Request()
                            {
                                Name = "Request_01",
                                Description = "Description_1_1",
                                EndDate = new DateTime(2023,10,1),
                                Email = "HaveNoInspirationUser@mail.ru",
                            },
                            new Request()
                            {
                                Name = "Request_02",
                                Description = "Description_1_2",
                                EndDate = new DateTime(2023,10,2),
                                Email = "HaveNoInspirationUser@mail.ru",
                            },
                            new Request()
                            {
                                Name = "Request_03",
                                Description = "Description_1_3",
                                EndDate = new DateTime(2023,10,3),
                                Email = "HaveNoInspirationUser@mail.ru",
                            },
                            new Request()
                            {
                                Name = "Request_04",
                                Description = "Description_1_4",
                                Email = "HaveNoInspirationUser@mail.ru",
                            },
                        }
                    }
                });
            }
        }
    }
}
