# Przykład użycia w Androidzie i Kotlinie

Poniżej znajduje się prosty przykład pokazujący:
- **suwak** w Androidzie (`SeekBar`) — odpowiednik webowego `input type="range"`
- **selection** w webie (`<select>`) — oraz jego odpowiednik w Androidzie (`Spinner`)

## Android / Kotlin — suwak (range)

### XML

```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    android:orientation="vertical"
    android:padding="16dp">

    <TextView
        android:id="@+id/tvSlider"
        android:layout_width="wrap_content"
        android:layout_height="wrap_content"
        android:text="Wartość: 50" />

    <SeekBar
        android:id="@+id/seekBar"
        android:layout_width="match_parent"
        android:layout_height="wrap_content"
        android:max="100"
        android:progress="50" />
</LinearLayout>
```

### Kotlin (`Activity`)

```kotlin
package com.example.demo

import android.os.Bundle
import android.widget.SeekBar
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity

class MainActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val seekBar = findViewById<SeekBar>(R.id.seekBar)
        val tvSlider = findViewById<TextView>(R.id.tvSlider)

        seekBar.setOnSeekBarChangeListener(object : SeekBar.OnSeekBarChangeListener {
            override fun onProgressChanged(sb: SeekBar?, progress: Int, fromUser: Boolean) {
                tvSlider.text = "Wartość: $progress"
            }

            override fun onStartTrackingTouch(sb: SeekBar?) {}
            override fun onStopTrackingTouch(sb: SeekBar?) {}
        })
    }
}
```

## Web — selection (`<select>`)

```html
<label for="sel">Wybierz opcję:</label>
<select id="sel">
  <option value="kotlin">Kotlin</option>
  <option value="csharp">C#</option>
  <option value="php">PHP</option>
  <option value="ts">TypeScript</option>
</select>

<p id="out">Wybrano: -</p>

<script>
  const sel = document.getElementById('sel');
  const out = document.getElementById('out');

  sel.addEventListener('change', () => {
    out.textContent = 'Wybrano: ' + sel.value;
  });
</script>
```

## Android — odpowiednik selection: `Spinner`

```kotlin
package com.example.demo

import android.os.Bundle
import android.view.View
import android.widget.AdapterView
import android.widget.ArrayAdapter
import android.widget.Spinner
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity

class MainActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val spinner = findViewById<Spinner>(R.id.spinner)
        val tvSelected = findViewById<TextView>(R.id.tvSelected)

        val items = listOf("Kotlin", "C#", "PHP", "TypeScript")

        spinner.adapter = ArrayAdapter(
            this,
            android.R.layout.simple_spinner_dropdown_item,
            items
        )

        spinner.onItemSelectedListener = object : AdapterView.OnItemSelectedListener {
            override fun onItemSelected(
                parent: AdapterView<*>?,
                view: View?,
                position: Int,
                id: Long
            ) {
                tvSelected.text = "Wybrano: ${items[position]}"
            }

            override fun onNothingSelected(parent: AdapterView<*>?) {}
        }
    }
}
```

## Podsumowanie

| Web | Android |
|---|---|
| `<input type="range">` | `SeekBar` |
| `<select>` | `Spinner` |
| `change` / `input` | `onProgressChanged` / `onItemSelected` |

