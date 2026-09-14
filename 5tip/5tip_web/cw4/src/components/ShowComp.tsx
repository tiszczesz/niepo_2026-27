import { useState } from 'react';
import './ShowComp.css';
const ShowComp = () => {
    const [isChecked, setIsChecked] = useState(true);
    return (
        <section className="info">
            {isChecked && <img src="images/piesek1.jpg" alt="piesek" />}
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

export default ShowComp