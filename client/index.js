let app = document.getElementById("app")

let exercises = JSON.parse(localStorage.getItem('exercises')) || [];

function handleOnLoad(){
    document.getElementById('viewAllExercisesButton').addEventListener('click', showAllExercises);
    document.getElementById('addExerciseButton').addEventListener('click', function() {
      
        const exerciseNumber = document.getElementById('exerciseNumber').value
        const exerciseType = document.getElementById('exerciseType').value
        const exerciseCompleted = document.getElementById('exerciseCompleted').value
        const exerciseDistance = document.getElementById('exerciseDistance').value

        const newExercise = {
            number: exerciseNumber,
            type: exerciseType,
            completed: exerciseCompleted,
            distance: exerciseDistance
        }

        exercises.push(newExercise)

        saveExerToLocalStorage()

        document.getElementById('exerciseNumber').value = ''
        document.getElementById('exerciseType').value = ''
        document.getElementById('exerciseCompleted').value = ''
        document.getElementById('exerciseDistance').value = ''

        
        createTable()
    })

    createTable()

}
window.onload = handleOnLoad;

function createTable(){
    //create table
   let tableBody = document.getElementById('exerciseTableBody');

    // Clear the existing table rows
    while (tableBody.firstChild) {
        tableBody.removeChild(tableBody.firstChild);
    }

    let table = document.createElement('TABLE')
    table.border = '1'
    table.id = 'exerciseTable'
    tableBody = document.createElement('TBODY')
    tableBody.id = 'exerciseTableBody'
    table.appendChild(tableBody)

    //create header row
    let tr = document.createElement('TR')
    tableBody.appendChild(tr)

    let th1 = document.createElement('TH')
    th1.width = 500
    th1.appendChild(document.createTextNode('ExerciseID'))
    tr.appendChild(th1)

    let th2 = document.createElement('TH')
    th2.width = 500
    th2.appendChild(document.createTextNode('Exercise Type'))
    tr.appendChild(th2)

    let th3 = document.createElement('TH')
    th3.width = 500
    th3.appendChild(document.createTextNode('Date Completed'))
    tr.appendChild(th3)

    let th4 = document.createElement('TH')
    th4.width = 500
    th4.appendChild(document.createTextNode('Distance'))
    tr.appendChild(th4)

    let th5 = document.createElement('TH')
    th5.width = 500
    th5.appendChild(document.createTextNode('Edit/Delete Exercise'))
    tr.appendChild(th5)


    
    //create data row
    exercises.forEach((exercise)=>{
        let tr = document.createElement('TR')
        tableBody.appendChild(tr)

        let td1 = document.createElement('TD')
        td1.width = 500
        td1.appendChild(document.createTextNode(`${exercise.number}`))
        tr.appendChild(td1)
       
        let td2 = document.createElement('TD')
        td2.width = 500
        td2.appendChild(document.createTextNode(`${exercise.type}`))
        tr.appendChild(td2)
        
        let td3 = document.createElement('TD')
        td3.width = 500
        td3.appendChild(document.createTextNode(`${exercise.completed}`))
        tr.appendChild(td3)

        let td4 = document.createElement('TD')
        td4.width = 500
        td4.appendChild(document.createTextNode(`${exercise.distance}`))
        tr.appendChild(td4)

        let td5 = document.createElement('TD')
        td5.width = 500

        let editButton = document.createElement('button')
        editButton.textContent = 'Edit'
        editButton.className = 'btn btn-outline-dark'
        editButton.addEventListener('click', () => {alert(`Editing exercise ${exercise.number}`)})
        td5.appendChild(editButton)

        let deleteButton = document.createElement('button')
        deleteButton.textContent = 'Delete'
        deleteButton.className = 'btn btn-outline-dark'
        deleteButton.addEventListener('click', () => {alert(`Deleting exercise ${exercise.number}`)})
        td5.appendChild(deleteButton)

        tr.appendChild(td5)
    })
    app.appendChild(table)
}

function saveExerToLocalStorage(){
    localStorage.setItem('exercises',JSON.stringify(exercises))
}

function showAllExercises(){
    createTable()
}