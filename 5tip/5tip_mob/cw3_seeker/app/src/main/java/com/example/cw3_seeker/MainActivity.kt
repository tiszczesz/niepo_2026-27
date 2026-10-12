package com.example.cw3_seeker

import android.os.Bundle
import android.widget.AdapterView
import android.widget.ArrayAdapter
import android.widget.SeekBar
import android.widget.Spinner
import android.widget.TextView
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }
        val seekBar = findViewById<SeekBar>(R.id.seekBar)
        val tvSeekbar = findViewById<TextView>(R.id.tVSeekbar)
        val spinner = findViewById<Spinner>(R.id.spinner)
        val tvSpinner = findViewById<TextView>(R.id.tVSpinner)
        seekBar.setOnSeekBarChangeListener(object : SeekBar.OnSeekBarChangeListener{
            override fun onProgressChanged(
                seekBar: SeekBar?,
                progress: Int,
                fromUser: Boolean
            ) {
               tvSeekbar.text = "Aktualna wartość: $progress";
            }

            override fun onStartTrackingTouch(seekBar: SeekBar?) {
                Toast.makeText(this@MainActivity, "Rozpoczęto przesuwanie suwaka",
                    Toast.LENGTH_SHORT).show()
            }

            override fun onStopTrackingTouch(seekBar: SeekBar?) {
                Toast.makeText(this@MainActivity, "Zakończono przesuwanie suwaka",
                    Toast.LENGTH_SHORT).show()
            }

        })
        val adapter = ArrayAdapter(this,
            android.R.layout.simple_spinner_item, data)
        spinner.adapter = adapter
        spinner.onItemSelectedListener = object : AdapterView.OnItemSelectedListener {
            override fun onItemSelected(
                parent: AdapterView<*>?,
                view: android.view.View?,
                position: Int,
                id: Long
            ) {
                val selectedValue = parent?.getItemAtPosition(position).toString()
                tvSpinner.text = "Wybrana wartość: $selectedValue"
            }

            override fun onNothingSelected(parent: AdapterView<*>?) {
                tvSpinner.text = "Nie wybrano żadnej wartości"
            }
        }
    }
}