# FuturesDiff
 
## Структура

Проект состоит из 3 микросервисов

- **MarketDataService** — получает данные о квартальных фьючерсах

- **CalculateService** — вычисляет разницу между двумя фьючерсами

- **StorageService** — сохраняет и отдает разницу в базу данных PostgreSQL

## Настройка

В корне `StorageService/` создать файл `.env`:

```bash
DB_CONNECTION=Host=localhost;Port=5432;Database=storage_db;Username=postgres;Password=yourpassword
```

## Запуск микросервисов

Каждый микросервис - отдельный Web Api

Зайдите в solution FuturesDiff

### MarketDataService

1. Заходим в папку сервиса

```bash
cd MarketDataService
```

2. Запускаем 

```bash
dotnet run --urls "https://localhost:5000"
```

### CalculationService

1. Заходим в папку сервиса

```bash
cd CalculationService
```

2. Запускаем 

```bash
dotnet run --urls "https://localhost:5001"
```

### StorageService

1. Заходим в папку сервиса

```bash
cd StorageService
```

2. Запускаем 

```bash
dotnet run --urls "https://localhost:5002"
```

## Куда заходить чтобы протестировать?

```bash
https://localhost:5002/swagger
```

## Данные для использования

Тестирование прходило на паре BTC

1. Пара BTCUSDT_250627

```bash
BTCUSDT_250627
```

2. Пара - BTCUSDT_250926

```bash
BTCUSDT_250926
```

3. Интервал 1 день

```bash
1d
```