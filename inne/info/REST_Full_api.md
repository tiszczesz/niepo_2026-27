# REST Full API – omówienie w punktach

## 1. Czym jest REST Full API?

- REST (Representational State Transfer) to styl architektury sieciowej oparty na protokole HTTP.
- API REST pozwala klientom komunikować się z serwerem za pomocą żądań HTTP.
- Typowa aplikacja REST Full API obejmuje:
  - backend serwera,
  - warstwę logiki biznesowej,
  - warstwę dostępu do danych,
  - endpointy HTTP,
  - mechanizmy autoryzacji i walidacji.
- Nazwa „full API” oznacza pełną implementację funkcjonalności CRUD i dodatkowych mechanizmów, np. uwierzytelnianie, filtrowanie, paginację, cache, logowanie.

## 2. Główne założenia REST

- Każdy zasób ma swój identyfikator (np. `/users/42`).
- Komunikacja odbywa się przez standardowe metody HTTP:
  - `GET` – pobieranie danych,
  - `POST` – tworzenie nowych zasobów,
  - `PUT` – pełna aktualizacja zasobu,
  - `PATCH` – częściowa aktualizacja,
  - `DELETE` – usuwanie zasobu.
- Serwer jest bezstanowy (stateless): każde żądanie zawiera wszystkie potrzebne informacje.
- Odpowiedzi mają format danych, np. JSON.
- Wspólny kontrakt komunikacji: endpointy, nagłówki, statusy HTTP, format odpowiedzi.

## 3. Typowa struktura aplikacji REST API

- Warstwa kontrolerów / endpointów:
  - obsługa żądań HTTP,
  - mapowanie URL na akcje aplikacji.
- Warstwa usług / logiki biznesowej:
  - walidacja zasad biznesowych,
  - przetwarzanie danych,
  - współpraca z repozytoriami.
- Warstwa repozytoriów / dostępu do danych:
  - operacje CRUD,
  - komunikacja z bazą danych.
- Warstwa modeli / encji:
  - reprezentacja danych,
  - typy DTO / request / response.
- Warstwa bezpieczeństwa:
  - uwierzytelnianie,
  - autoryzacja,
  - ochrona przed atakami.

## 4. Przykładowe endpointy

- `GET /api/users` – pobranie wszystkich użytkowników
- `GET /api/users/5` – pobranie konkretnego użytkownika
- `POST /api/users` – utworzenie użytkownika
- `PUT /api/users/5` – pełna aktualizacja danych użytkownika
- `PATCH /api/users/5` – częściowa aktualizacja
- `DELETE /api/users/5` – usunięcie użytkownika
- `GET /api/orders?status=paid&page=2&limit=20` – filtrowanie i paginacja

## 5. Model danych i zasoby

- Zasób to jednostka biznesowa, np. użytkownik, produkt, zamówienie, faktura.
- Każdy zasób powinien mieć:
  - unikalny identyfikator,
  - pola opisu i statusu,
  - odpowiedni typ danych i walidację.
- Dobrą praktyką jest rozdzielenie modeli:
  - `Entity` – dane przechowywane w bazie,
  - `DTO` – dane przesyłane przez API,
  - `Request` – dane wejściowe od klienta,
  - `Response` – dane zwracane klientowi.

## 6. Statusy HTTP

- `200 OK` – żądanie zakończone powodzeniem
- `201 Created` – zasób utworzony
- `204 No Content` – operacja wykonana bez treści odpowiedzi
- `400 Bad Request` – błędne dane wejściowe
- `401 Unauthorized` – brak lub niepoprawny token
- `403 Forbidden` – brak uprawnień
- `404 Not Found` – zasób nie istnieje
- `409 Conflict` – konflikt danych, np. duplikat
- `500 Internal Server Error` – błąd serwera

## 7. Autoryzacja i uwierzytelnianie

- Najczęściej stosowane mechanizmy:
  - token JWT,
  - OAuth 2.0,
  - API keys,
  - sesje i cookies w niektórych aplikacjach.
- W praktyce:
  - użytkownik loguje się,
  - serwer zwraca token,
  - klient dodaje token do nagłówka `Authorization`,
  - serwer weryfikuje token przy każdym żądaniu.
- Warto rozdzielić role:
  - użytkownik,
  - moderator,
  - administrator.

## 8. Walidacja danych

- Walidacja powinna odbywać się na poziomie:
  - wejścia API,
  - logiki biznesowej,
  - bazy danych.
- Do sprawdzania danych używa się np.:
  - wymagalności pól,
  - długości tekstu,
  - poprawności emaila,
  - formatu dat,
  - limitów liczbowych.
- Zaleca się zwracanie czytelnych komunikatów błędów.

## 9. Obsługa błędów

- Aplikacja powinna mieć spójny model błędów.
- Dobre podejście to struktura odpowiedzi typu:
  - `code`
  - `message`
  - `details`
  - `timestamp`
- Błędy powinny być:
  - czytelne,
  - bezpieczne,
  - nie ujawniające zbyt wielu szczegółów technicznych.

## 10. Paginacja, filtrowanie i sortowanie

- W większych systemach API nie zwraca dużych zbiorów danych naraz.
- Typowe mechanizmy:
  - `page` i `limit`,
  - `sortBy`,
  - `order`,
  - filtry po polach (`status`, `category`, `createdAt`).
- Pozwala to:
  - zmniejszyć obciążenie bazy,
  - poprawić wydajność,
  - upraszczać pracę klienta.

## 11. Wersjonowanie API

- Wersjonowanie pomaga utrzymać kompatybilność między klientami.
- Typowe rozwiązania:
  - `/api/v1/users`
  - nagłówek `Accept: application/vnd.company.v1+json`
- Warto planować kompatybilność przy zmianach endpointów i modeli danych.

## 12. Bezpieczeństwo REST API

- Ochrona przed atakami typu:
  - SQL Injection,
  - XSS,
  - CSRF,
  - brute force,
  - przepełnienie buforów i nieprawidłowe dane wejściowe.
- Dobre praktyki:
  - szyfrowanie komunikacji HTTPS,
  - bezpieczne przechowywanie tokenów,
  - ograniczanie uprawnień,
  - logowanie zdarzeń i prób dostępu,
  - ograniczanie liczby żądań (rate limiting).

## 13. Testowanie API

- Testy powinny obejmować:
  - poprawność endpointów,
  - poprawność statusów HTTP,
  - walidację danych wejściowych,
  - mechanizmy bezpieczeństwa,
  - scenariusze błędów.
- Typy testów:
  - testy jednostkowe,
  - testy integracyjne,
  - testy end-to-end,
  - testy bezpieczeństwa.

## 14. Dokumentacja API

- Dobra dokumentacja API zawiera:
  - opis endpointów,
  - parametry wejściowe,
  - przykładowe żądania i odpowiedzi,
  - statusy błędów,
  - zasady uwierzytelniania,
  - ograniczenia i wymagania.
- Popularne narzędzia:
  - Swagger / OpenAPI,
  - Postman,
  - Redoc.

## 15. Zalety aplikacji REST Full API

- Prosta architektura i łatwość utrzymania.
- Współpraca z różnymi klientami: web, mobile, desktop.
- Standardowy protokół HTTP i JSON.
- Skalowalność i możliwość rozbudowy.
- Czytelność i łatwość integracji z innymi systemami.

## 16. Wady i ograniczenia

- Wymaga dobrego projektowania endpointów i modeli danych.
- Złożone scenariusze mogą wymagać dodatkowej logiki.
- Bez odpowiedniego bezpieczeństwa API może być podatne na ataki.
- W dużych systemach łatwo o brak spójności w modelu danych.

## 17. Podsumowanie

- REST Full API to pełny, nowoczesny interfejs backendowy oparty na standardzie HTTP.
- Składa się z zasobów, endpointów, walidacji, autoryzacji i obsługi błędów.
- Dobrze zaprojektowane API jest bezpieczne, skalowalne i łatwe do integracji.
- W praktyce najważniejsze są: spójny model danych, bezpieczeństwo, przejrzysta dokumentacja i poprawne testowanie.

## 18. Przykład prostego flow aplikacji

- Klient wysyła żądanie `GET /api/products`
- Serwer weryfikuje token uwierzytelniający
- Aplikacja pobiera dane z bazy
- Serwer formatuje odpowiedź JSON
- Klient otrzymuje status HTTP i dane
- W przypadku błędu API zwraca odpowiedni kod i opis problemu

## 19. Najważniejsze zasady projektowania REST API

- Używaj rzeczowników w endpointach, nie czasowników.
- Zachowuj spójność nazw endpointów.
- Nie mieszaj różnych zasobów w jednym endpointzie.
- Pamiętaj o statusach HTTP i odpowiedniej strukturze błędów.
- Dokumentuj API i testuj każdą główną ścieżkę.
- Projektuj API pod przyszłe zmiany, nie tylko pod bieżące potrzeby.

## 20. Wniosek

- REST Full API jest jednym z najczęściej stosowanych wzorców budowy backendów.
- Jest prosty do zrozumienia, wydajny i dobrze współpracuje z nowoczesnymi aplikacjami webowymi i mobilnymi.
- Dobra implementacja REST API wymaga nie tylko poprawnego kodu, ale także przemyślanej architektury, bezpieczeństwa i dokumentacji.

## 21. Krótka lista kontrolna projektu API

- [ ] Zdefiniowane zasoby i endpointy
- [ ] Zaimplementowane metody HTTP
- [ ] Walidacja danych wejściowych
- [ ] Autoryzacja i role użytkowników
- [ ] Obsługa błędów i statusy HTTP
- [ ] Dokumentacja OpenAPI / Swagger
- [ ] Testy jednostkowe i integracyjne
- [ ] Bezpieczne przechowywanie danych i tokenów
- [ ] Paginacja i filtrowanie
- [ ] Logowanie i monitorowanie

