# MobilePark.Backend

Надо написать веб апи на C# с использованием .net 8, которая будет предоставлять метод получения списка новостей с подсчетом 
количесва гласных в выбранном фрагменте.  
Параметрами метода будут 
- ключевое слово по которому будет вестись поиск 
- указание фрагмента новости, по которому будет вестись подсчет букв
- язык - русский / английский
Метод возвращает список объектов , содержащих фрагмент новости и количество гласных.
Список должен быть отсортирован по убыванию найденных гласных - наибольшее в начале. 
Для получения новостей использовать сервис [https://newsapi.org](https://newsapi.org/) - там регаемся, получаем бесплатный ключ и через него работаем. Нам отдавать его не нужно, надо предусмотреть возможность его конфигурации. 

Бонусное опциональное задание со звездочкой - писать в базу в лог запросов с указанием параметров и результатов.
Работу с базой вести через EF . Схему спроектировать на свое усмотрение . 

Общее пожелание - не использовать chatgpt для кодогенерации. 
