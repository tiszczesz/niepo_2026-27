# Android: przełączanie między Activity i Fragmentami

Tutorial pokazuje dwa sposoby przełączania ekranów w aplikacji Android napisanej w Kotlinie:

1. aplikacja z dwoma `Activity`,
2. aplikacja z jednym `Activity` i dwoma `Fragment`.

W obu przykładach każdy ekran wyświetla swoją nazwę i przycisk przełączający na drugi ekran.

> Przykłady zakładają projekt Android w Kotlinie z widokami XML. W kodzie zastąp `com.example.demo` pakietem używanym w swoim projekcie. Przykłady z `MainActivity` są alternatywne — w projekcie wybierz rozwiązanie z Activity albo z Fragmentami.

---

## 1. Dwa Activity

Każde `Activity` jest osobnym ekranem aplikacji. Do przełączenia się na drugie używamy `Intent` i `startActivity()`.

### Krok 1: utwórz układy XML

W katalogu `res/layout` utwórz plik `activity_main.xml`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    android:gravity="center"
    android:orientation="vertical"
    android:padding="24dp">

    <TextView
        android:id="@+id/activityName"
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:text="Activity: MainActivity"
        android:textSize="24sp" />

    <Button
        android:id="@+id/switchButton"
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:layout_marginTop="16dp"
        android:text="Przejdź do SecondActivity" />
</LinearLayout>
```

Utwórz też plik `activity_second.xml`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    android:gravity="center"
    android:orientation="vertical"
    android:padding="24dp">

    <TextView
        android:id="@+id/activityName"
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:text="Activity: SecondActivity"
        android:textSize="24sp" />

    <Button
        android:id="@+id/switchButton"
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:layout_marginTop="16dp"
        android:text="Wróć do MainActivity" />
</LinearLayout>
```

### Krok 2: dodaj kod Activity

W `MainActivity.kt` ustaw widok i obsłuż przycisk:

```kotlin
package com.example.demo

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import androidx.appcompat.app.AppCompatActivity

class MainActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        findViewById<Button>(R.id.switchButton).setOnClickListener {
            startActivity(Intent(this, SecondActivity::class.java))
        }
    }
}
```

Utwórz plik `SecondActivity.kt`:

```kotlin
package com.example.demo

import android.content.Intent
import android.os.Bundle
import android.widget.Button
import androidx.appcompat.app.AppCompatActivity

class SecondActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_second)

        findViewById<Button>(R.id.switchButton).setOnClickListener {
            startActivity(Intent(this, MainActivity::class.java))
        }
    }
}
```

### Krok 3: zarejestruj Activity w manifeście

W `AndroidManifest.xml`, wewnątrz elementu `<application>`, zarejestruj oba ekrany. `MainActivity` pozostaje ekranem startowym:

```xml
<activity
    android:name=".SecondActivity"
    android:exported="false" />

<activity
    android:name=".MainActivity"
    android:exported="true">
    <intent-filter>
        <action android:name="android.intent.action.MAIN" />
        <category android:name="android.intent.category.LAUNCHER" />
    </intent-filter>
</activity>
```

Po uruchomieniu aplikacji zobaczysz `MainActivity`. Kliknięcie przycisku otworzy `SecondActivity`, a przycisk na drugim ekranie uruchomi `MainActivity`.

---

## 2. Jedno Activity i przełączanie między Fragmentami

`Fragment` jest częścią interfejsu umieszczaną wewnątrz `Activity`. W tym przykładzie `MainActivity` pozostaje otwarte, a jego zawartość jest wymieniana na jeden z dwóch Fragmentów.

### Krok 1: utwórz kontener w Activity

Utwórz lub zmień plik `activity_main.xml`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<FrameLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:id="@+id/fragmentContainer"
    android:layout_width="match_parent"
    android:layout_height="match_parent" />
```

`FrameLayout` będzie miejscem, w którym aplikacja wyświetli Fragment.

### Krok 2: przygotuj układy Fragmentów

Utwórz `fragment_first.xml`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    android:gravity="center"
    android:orientation="vertical"
    android:padding="24dp">

    <TextView
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:text="Fragment: FirstFragment"
        android:textSize="24sp" />

    <Button
        android:id="@+id/switchButton"
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:layout_marginTop="16dp"
        android:text="Przejdź do SecondFragment" />
</LinearLayout>
```

Utwórz `fragment_second.xml`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    android:gravity="center"
    android:orientation="vertical"
    android:padding="24dp">

    <TextView
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:text="Fragment: SecondFragment"
        android:textSize="24sp" />

    <Button
        android:id="@+id/switchButton"
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:layout_marginTop="16dp"
        android:text="Wróć do FirstFragment" />
</LinearLayout>
```

### Krok 3: wyświetl pierwszy Fragment

W `MainActivity.kt` pokaż pierwszy Fragment przy pierwszym tworzeniu ekranu:

```kotlin
package com.example.demo

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity

class MainActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        if (savedInstanceState == null) {
            supportFragmentManager.beginTransaction()
                .replace(R.id.fragmentContainer, FirstFragment())
                .commit()
        }
    }
}
```

Warunek `savedInstanceState == null` zapobiega ponownemu dodaniu początkowego Fragmentu po odtworzeniu Activity, na przykład po obrocie ekranu.

### Krok 4: utwórz Fragmenty i obsłuż przełączanie

Utwórz `FirstFragment.kt`:

```kotlin
package com.example.demo

import android.os.Bundle
import android.view.View
import android.widget.Button
import androidx.fragment.app.Fragment

class FirstFragment : Fragment(R.layout.fragment_first) {

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        view.findViewById<Button>(R.id.switchButton).setOnClickListener {
            parentFragmentManager.beginTransaction()
                .replace(R.id.fragmentContainer, SecondFragment())
                .addToBackStack(null)
                .commit()
        }
    }
}
```

Utwórz `SecondFragment.kt`:

```kotlin
package com.example.demo

import android.os.Bundle
import android.view.View
import android.widget.Button
import androidx.fragment.app.Fragment

class SecondFragment : Fragment(R.layout.fragment_second) {

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        view.findViewById<Button>(R.id.switchButton).setOnClickListener {
            parentFragmentManager.beginTransaction()
                .replace(R.id.fragmentContainer, FirstFragment())
                .addToBackStack(null)
                .commit()
        }
    }
}
```

`addToBackStack(null)` dodaje przejście do stosu nawigacji. Dzięki temu przycisk systemowego „Wstecz” może wrócić do poprzedniego Fragmentu.

---

## Porównanie

| Rozwiązanie                | Co jest przełączane?                  | Sposób przełączenia                |
| -------------------------- | ------------------------------------- | ---------------------------------- |
| Dwa Activity               | Cały ekran aplikacji                  | `startActivity(Intent(...))`       |
| Jedno Activity i Fragmenty | Zawartość kontenera wewnątrz Activity | `FragmentTransaction.replace(...)` |

`Activity` sprawdza się jako osobny ekran aplikacji. `Fragment` pozwala wymieniać części interfejsu bez uruchamiania kolejnego Activity.
