# Przykład użycia CheckBox i RadioButton w Androidzie i Kotlinie

Poniżej znajduje się prosty przykład pokazujący:
- **checkbox** w Androidzie (`CheckBox`) — odpowiednik webowego `input type="checkbox"`
- **radio button** w Androidzie (`RadioButton` z `RadioGroup`) — odpowiednik webowego `input type="radio"`

## Android / Kotlin — CheckBox (dwa komponenty)

### XML

```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    android:orientation="vertical"
    android:padding="16dp">

    <TextView
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:text="Wybierz opcje:"
        android:textSize="18sp"
        android:textStyle="bold" />

    <CheckBox
        android:id="@+id/checkboxKotlin"
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:text="Kotlin" />

    <CheckBox
        android:id="@+id/checkboxCSharp"
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:text="C#" />

    <TextView
        android:id="@+id/tvCheckboxResult"
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:text="Wybrano: -"
        android:layout_marginTop="16dp" />
</LinearLayout>
```

### Kotlin (`Activity`)

```kotlin
package com.example.demo

import android.os.Bundle
import android.widget.CheckBox
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity

class MainActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val checkboxKotlin = findViewById<CheckBox>(R.id.checkboxKotlin)
        val checkboxCSharp = findViewById<CheckBox>(R.id.checkboxCSharp)
        val tvCheckboxResult = findViewById<TextView>(R.id.tvCheckboxResult)

        val updateCheckboxStatus = {
            val selected = mutableListOf<String>()
            if (checkboxKotlin.isChecked) selected.add("Kotlin")
            if (checkboxCSharp.isChecked) selected.add("C#")
            
            tvCheckboxResult.text = "Wybrano: ${selected.joinToString(", ")}"
        }

        checkboxKotlin.setOnCheckedChangeListener { _, _ -> updateCheckboxStatus() }
        checkboxCSharp.setOnCheckedChangeListener { _, _ -> updateCheckboxStatus() }
    }
}
```

## Web — CheckBox (`input type="checkbox"`)

```html
<label for="cb1">
  <input type="checkbox" id="cb1" value="kotlin"> Kotlin
</label>

<label for="cb2">
  <input type="checkbox" id="cb2" value="csharp"> C#
</label>

<p id="cbOut">Wybrano: -</p>

<script>
  const cb1 = document.getElementById('cb1');
  const cb2 = document.getElementById('cb2');
  const cbOut = document.getElementById('cbOut');

  const updateCheckboxes = () => {
    const selected = [];
    if (cb1.checked) selected.push('Kotlin');
    if (cb2.checked) selected.push('C#');
    cbOut.textContent = 'Wybrano: ' + (selected.length > 0 ? selected.join(', ') : '-');
  };

  cb1.addEventListener('change', updateCheckboxes);
  cb2.addEventListener('change', updateCheckboxes);
</script>
```

## Android / Kotlin — RadioButton z RadioGroup (dwa komponenty)

### XML

```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    android:orientation="vertical"
    android:padding="16dp">

    <TextView
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:text="Wybierz jeden język:"
        android:textSize="18sp"
        android:textStyle="bold" />

    <RadioGroup
        android:id="@+id/radioGroup"
        android:layout_width="wrap_content"
        android:layout_height="wrap_content">

        <RadioButton
            android:id="@+id/radioPHP"
            android:layout_width="wrap_content"
            android:layout_height="wrap_content"
            android:text="PHP" />

        <RadioButton
            android:id="@+id/radioTypeScript"
            android:layout_width="wrap_content"
            android:layout_height="wrap_content"
            android:text="TypeScript" />

    </RadioGroup>

    <TextView
        android:id="@+id/tvRadioResult"
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:text="Wybrano: -"
        android:layout_marginTop="16dp" />
</LinearLayout>
```

### Kotlin (`Activity`)

```kotlin
package com.example.demo

import android.os.Bundle
import android.widget.RadioButton
import android.widget.RadioGroup
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity

class MainActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val radioGroup = findViewById<RadioGroup>(R.id.radioGroup)
        val tvRadioResult = findViewById<TextView>(R.id.tvRadioResult)

        radioGroup.setOnCheckedChangeListener { _, checkedId ->
            val selectedRadio = findViewById<RadioButton>(checkedId)
            tvRadioResult.text = "Wybrano: ${selectedRadio.text}"
        }
    }
}
```

## Web — RadioButton (`input type="radio"`)

```html
<p>Wybierz jeden język:</p>

<label for="rb1">
  <input type="radio" id="rb1" name="lang" value="php"> PHP
</label>

<label for="rb2">
  <input type="radio" id="rb2" name="lang" value="ts"> TypeScript
</label>

<p id="rbOut">Wybrano: -</p>

<script>
  const radios = document.querySelectorAll('input[name="lang"]');
  const rbOut = document.getElementById('rbOut');

  radios.forEach(radio => {
    radio.addEventListener('change', () => {
      if (radio.checked) {
        rbOut.textContent = 'Wybrano: ' + radio.value;
      }
    });
  });
</script>
```

## Podsumowanie

| Web | Android |
|---|---|
| `<input type="checkbox">` | `CheckBox` |
| `<input type="radio">` | `RadioButton` |
| `<fieldset>` / naming convention | `RadioGroup` |
| `change` event | `setOnCheckedChangeListener` |
| Multiple selections | Multiple selections allowed |
| Single selection per group | Only one per `RadioGroup` |

