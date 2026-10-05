package com.example.cw2

import android.os.Bundle
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.EditText
import android.widget.ListView
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

        val editContact = findViewById<EditText>(R.id.editContact)
        val btnAdd = findViewById<Button>(R.id.addButton)
        val listContacts = findViewById<ListView>(R.id.listViewContacts)
        //zdefiniowanie adaptera
        val adapterList = ArrayAdapter<String>(
            this, android.R.layout.simple_list_item_1, contacts
        )
        //podpiecie adaptera do ListView
        listContacts.adapter = adapterList

        //dodawanie do listView
        btnAdd.setOnClickListener {
            val newContact = editContact.text.toString().trim()
            if (newContact.isEmpty()) {
                Toast.makeText(
                    this, "Brak danych",
                    Toast.LENGTH_SHORT
                ).show()
            } else {
                //dodanie do listy String
                contacts.add(newContact)
                //wymuszenie przeładowania ListView
                adapterList.notifyDataSetChanged()
                editContact.text.clear()
            }
        }
        //usuwanie z listy na kliknięcie elemntu listy
        listContacts.setOnItemClickListener { parent, view, position, id ->

            Toast.makeText(
                this, "kliknieto element o id: $id",
                Toast.LENGTH_SHORT
            ).show()
            contacts.removeAt(id.toInt())
            adapterList.notifyDataSetChanged()
        }
    }
}