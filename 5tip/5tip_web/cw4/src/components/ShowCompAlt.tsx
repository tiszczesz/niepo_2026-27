import { useState } from 'react';
import piesek2 from '../assets/piesek2.jpg'
import './ShowComp.css'



const ShowCompAlt = () => {
    const [isChecked, setIsChecked] = useState(true);
    return (
        <section className="info">
            {isChecked && <img src={piesek2} alt="piesek" />}
            <section className='d-flex flex-row align-items-center'>
                <label htmlFor="showHide">
                    {isChecked ? 'Ukryj obrazek' : 'Pokaż obrazek'}
                </label>
                <input
                    onClick={() => setIsChecked(!isChecked)}
                    className="form-check-input" style={{ marginLeft: '20px' }} type="checkbox" id="showHide" />

            </section>
        </section>
    )

}

export default ShowCompAlt