window.displayChart = function (labels, data, idName) {
    const ctx = document.getElementById(idName);

    new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: idName,
                data: data,
                borderWidth: 1,
                backgroundColor: ["green", "blue", "yellow", "beige", "bronze", "blue"]
            }],
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            },
            indexAxis: 'y',
            animations: {
                tension: {
                    duration: 2000,
                    easing: 'linear',
                    from: 1,
                    to: 0,
                    loop: true
                }
            }
        }
    });
}