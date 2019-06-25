Vue.component('weekplan',
    {
        props: ['classes', 'participant'],
        data: function(){
            return {
                days: [
                    {id: 0, text: 'Mandag'},
                    {id: 1, text: 'Tirsdag'},
                    {id: 2, text: 'Onsdag'},
                    {id: 3, text: 'Torsdag'},
                    {id: 4, text: 'Fredag'}
                ],
            
            timeslots: getTimeslots(8.5, 15, 0.25)
            }
        },
        methods: {
            getText: function (day, time){
                const participant = this.participant;
                if (!participant) return '';
                const classes = this.classes.filter(c=> c.day 
                                            && c.time === time  
                                            && c.participants.includes(participant));
                if(classes.length === 0) return '';
                return classes[0].text;
        },
            getTimeslots: function(start, stop, duration){
                const timeslots = [];
                for(let time = start; time <=stop; time += duration){
                timeslots.push({id: timeslots.length, text: timeFromFloat(time)});
            }
                return timeslots;
        },
            timeFromFloat: function(time){
            let minutes = 60 * (time % 1);
            if(minutes < 10) minutes = '0'+minutes;
            return Math.floor(time) + ':' + minutes;
        }
    },
    template: `<table>
    <tr>
        <th></th>
        <th v-for="day in days">{{day.text}}</th>
    </tr>

    <tr v-for="time in timeslots">
        <td>{{time.text}}</td>
        <td v-for="day in days">{{getText(day.text, time.text)}}</td>
    </tr>
</table>`

    });