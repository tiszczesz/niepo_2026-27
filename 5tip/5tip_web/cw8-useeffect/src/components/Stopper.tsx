import React from 'react'

type Props = {
    duration: number
}

const Stopper = (props: Props) => {
  return (
    <div>Stopper całkowity czas: {props.duration}</div>
  )
}

export default Stopper