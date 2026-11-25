package com.example.filter1

import android.os.Bundle
import android.text.Editable
import android.text.TextWatcher
import android.widget.ArrayAdapter
import android.widget.EditText
import android.widget.ListView
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import androidx.core.widget.doOnTextChanged

class MainActivity : AppCompatActivity() {
    private val colors = listOf(
        "white","green","blue","yellow","purple","gray","red","black",
        "orange","pink","brown","cyan","magenta","lime","navy","teal","olive","maroon",
    )
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }
        val edSearch = findViewById<EditText>(R.id.tvSearch)
        val listColor = findViewById<ListView>(R.id.listView)
        val adapter = ArrayAdapter(this, android.R.layout.simple_list_item_1,
            colors.toMutableList())
        listColor.adapter = adapter
//        edSearch.addTextChangedListener(object : TextWatcher {
//            override fun beforeTextChanged(s: CharSequence?, start: Int, count: Int, after: Int) = Unit
//            override fun onTextChanged(s: CharSequence?, start: Int, before: Int, count: Int) = Unit
//            override fun afterTextChanged(s: Editable?) {
//                val query = s?.toString().orEmpty()
//                adapter.clear()
//                adapter.addAll(colors.filter { it.contains(query, ignoreCase = true) })
//            }
//        })

        edSearch.doOnTextChanged { text, start, before, count ->
            val query = text?.toString().orEmpty()
            adapter.clear()
            adapter.addAll(colors.filter { it.contains(query, ignoreCase = true) })
        }
    }
}