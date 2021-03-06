# Инструкция по работе с данным API:
####	Для начала работы:
	1. Добавьте папку RestAPI в папку со своим решением;
	2. Подключите проект к своему решению, для этого(если вы работаете в Visual Studio):
		1. Откройте свое решение в VS;
		2. Щелкните правой кнопкой мыши по нему в поле Solution Explorer;
		3. Далее:
			1. В появившемся контексном меню выбирайте последовательно следующие пункты:
				Add -> Existing Project...
		 	2. Найдите в папке RestAPI файл RestAPI.csproj и выбирете его;
	3. Подключите проект RestAPI к проектам, которые будут с ним работать;
	4. Для работы с API добавьте его в список проектов, которые запускаются при запуске решения;
	5. Для работы с моделями конференций добавьте в свой код:
		using RestAPI.Models
	6. Для обработки исключений, которые может возвращать API при вводе неверных данных, добавьте в свой код:
		using RestAPI.Common.CustomExceptions
			
### Использование API: (Для обмена данными API использует фомат json)

####	1. Get запросы:
	1. Для получения всех конференций отправьте http-get запрос по адресу: https://localhost:44346/api/conferences;
		1. При корректном указании запроса, в качестве ответа вы получите:
		  	List<ConferenceWithoutID>, где будет храниться вся информация обо всех конференциях;
		2. При некорректном указании адреса запроса, вы получите исключение:
			System.Net.WebException: 'The remote server returned an error: (404) Not Found.';
   	2. Для получения конференций по названию отправьте http-get запрос по адресу:
		   https://localhost:44346/api/conferences/getbytitle?title=[название конференции]
		1. При корректном указании запроса, в качестве ответа вы получите: List<ConferenceWithoutID>,
			где будет храниться вся информация обо всех конференциях с данным названием;
		2. При некорректном указании адреса запроса, вы получите исключение:
			System.Net.WebException: 'The remote server returned an error: (404) Not Found.';
		3. Если конференций с данным названием не найдется, вы получите исключение:
			RestAPI.Common.CustomExceptions.NotFoudException: 'Conferences are not found', с кодом 404;

####	2. Post запросы:
	1. Для добавления новой конференции отправьте http-post запрос по адресу: https://localhost:44346/api/conferences,
		    в тело запроса положите объект класса ConferencesWithoutIDModel, сериализованный в json формат
		1. При корректном указании запроса, конференция будет добавлена в список всех конференций, 
			а в качестве ответа вы получите: id добавленной конференции (его необходимо запомнить);
		2. При некорректном указании адреса запроса, вы получите исключение:
			System.Net.WebException: 'The remote server returned an error: (404) Not Found.';
		3. При некорректном указании тела запроса, вы получите исключение:
			System.Net.WebException: 'The remote server returned an error: (400) Bad Request.';

####	3. Put запросы:
	1. Для обновления данных о конференции отправьте http-put запрос по адресу: 
		    https://localhost:44346/api/conferences?id=[id конференции], в тело запроса 
		    положите объект класса   ConferencesWithoutIDModel, сериализованный в json формат
		1. При корректном указании запроса, конференция будет обновлена;
		2. При некорректном указании адреса запроса, вы получите исключение:
			System.Net.WebException: 'The remote server returned an error: (404) Not Found.';
		3. При некорректном указании тела запроса, вы получите исключение:
			System.Net.WebException: 'The remote server returned an error: (400) Bad Request.';
		4. Если конференция с данным id не найдется, вы получите исключение:
			RestAPI.Common.CustomExceptions.NotFoudException: 'Conferences are not found', с кодом 404;
	
####	4. Delete запросы:
	1. Для удаления конференции отправьте http-delete запрос по адресу: 
		    https://localhost:44346/api/conferences?id=[id конференции] 
		1. При корректном указании запроса, конференция будет удалена.
		2. При некорректном указании адреса запроса, вы получите исключение:
			System.Net.WebException: 'The remote server returned an error: (404) Not Found.'
		3. Если конференция с данным id не найдется, вы получите исключение:
			RestAPI.Common.CustomExceptions.NotFoudException: 'Conferences are not found', с кодом 404
