import { useState } from "react";

type Props = {
  title?: string;
};
type FormResult = {
  firstname: string;
  lastname: string;
  myDate: string;
};
const FormAction = ({ title }: Props) => {
  const [result, setResult] = useState<FormResult | undefined>(undefined);

  function actionHandle(formData: FormData): void | Promise<void> {
    console.log(formData.entries);
    if (
        (formData.get("firstname")as string).trim() !== "" &&
        (formData.get("lastname")as string).trim() !== "" &&
        (formData.get("myDate")as string).trim() !== "" 
    )
      setResult({
        firstname: formData.get("firstname") as string,
        lastname: formData.get("lastname") as string,
        myDate: formData.get("myDate") as string,
      });
      //to jest zwykle wcześniej niż setResult, bo setResult jest asynchroniczne
      console.log(result);
      
  }

  return (
    <>
      <h2>Tytuł formularza: {title}</h2>
      <form action={actionHandle}>
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
      {result && (
        <div>
          imię: {result.firstname}, nazwisko: {result.lastname}, data:{" "}
          {result.myDate}
        </div>
      )}
      <hr />
    </>
  );
};

export default FormAction;
