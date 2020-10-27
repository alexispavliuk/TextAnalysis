# TextAnalysis
С помощью этого веб-приложения можно получить некоторые возможности анализа текста.
- Сервер представляет собой Web-API приложение с одним контроллером, статическим классом TextAnalyzer и моделью запроса RequestData.
- Фронтенд написан на чистом html/css/js
- Запросы на сервер осуществляются с помощью fetch
- Нужный метод обработки выбирается путем отражения.
- Для того чтобы добавить функционал, нужно добавить соответственный метод в класс TextAnalyzer и прописать его название в script.js
- Так же добавлен функционал Amazon Web Services Comprehend, а именно определение языка текста и его эмоциональность.
- Для того, чтобы это работало, нужно прописать свой id и ключ из кабинета аккаунта AWS в том же классе TextAnalyzer.