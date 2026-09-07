package com.example.cw1

import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
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
        //Inicjowanie zmiennych kontrolek UI
        val emailText = findViewById<EditText>(R.id.editTextEmail)
        val passwordText = findViewById<EditText>(R.id.editPassword)
        val passwordRepeatText = findViewById<EditText>(R.id.editPasswordRepeat)
        val resultText = findViewById<TextView>(R.id.result)
        val registerButton = findViewById<Button>(R.id.button)

        //Obsługa kliknięcia przycisku rejestracji
        registerButton.setOnClickListener {
            val email = emailText.text.toString()
            //Walidacja adresu email
            if(!email.contains("@"))
             {
                resultText.text  = "Nieprawidłowy adres e-mail";
                return@setOnClickListener
            }
            //Walidacja hasła
            //Sprawdzamy, czy hasło ma co najmniej 3 znaków nie ma w arkuszu
            val password = passwordText.text.toString()
            val passwordRepeat = passwordRepeatText.text.toString()
            if(password.length < 3)
            {
                resultText.text  = "Hasło musi mieć co najmniej 3 znaki";
                return@setOnClickListener
            }
            if(password != passwordRepeat)
            {
                resultText.text  = "Hasła się różnią";
                return@setOnClickListener
            }
            //Jeśli wszystkie walidacje przeszły, wyświetlamy komunikat o sukcesie
            resultText.text = "Witaj $email"
        }
    }
}