import React, {type SubmitEvent} from 'react'

type Props = {
    title?:string
}

const FormSubmit = ({title}: Props) => {


    function handmeSubmit(event: SubmitEvent<HTMLFormElement>): void {
        event.preventDefault();
        const formData:FormData = new FormData(event.currentTarget);
        console.log(formData);
        //reszta identycznie jak z action
    }

  return (
    <>
     <h2>Tytuł formularza: {title}</h2>
      <form onSubmit={(event)=>handmeSubmit(event)}>
        <input type="text" name="firstname" placeholder="Podaj imię" /> <br />
        <input type="text" name="lastname" placeholder="Podaj nazwisko" />{" "}
        <br />
        <input
          type="date"
          name="myDate"
          placeholder="Podaj datę urodzenia"
        />{" "}
        <br />
        <input
          type="submit"
          value="Zapisz"
          className="btn btn-outline-primary"
        />
      </form>
      {/* {result && (
        <div>
          imię: {result.firstname}, nazwisko: {result.lastname}, data:{" "}
          {result.myDate}
        </div>
      )} */}
      <hr />
    </>
  )
}

export default FormSubmit