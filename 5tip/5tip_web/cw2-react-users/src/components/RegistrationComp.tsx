import { useState } from 'react'
import './RegistrationComp.css'
const RegistrationComp = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [result, setResult] = useState('Autor: XXXXXXXXX');
    function handleRegistration(e: any) {
        throw new Error('Function not implemented.');
    }

    return (
        <section className="registration">
            <h2>Rejestruj konto</h2>
            <label htmlFor="email">
                Podaj email:
            </label>
            <input id="email" type="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                placeholder="Wpisz email" />
           
            <label htmlFor="password">
                Podaj hasło:
            </label>
            <input id="password" type="password" 
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            placeholder="Wpisz hasło" />
            <label htmlFor="password">
                Powtórz hasło:
            </label>
            <input id="passwordRepeat" type="password" 
            value={confirmPassword}
            onChange={(e) => setConfirmPassword(e.target.value)}
            placeholder="Wpisz hasło" />
            <button onclick={(e)=>handleRegistration(e)}>ZATWIERDŹ</button>
            <section>{result}</section>
        </section>
    )
}
export default RegistrationComp