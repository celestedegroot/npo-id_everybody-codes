const uri = "csvfile";

const map = L.map('map').setView([52.09140,5.11150], 14);

L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
  maxZoom: 19,
  attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
}).addTo(map);

getCameras();

function getCameras()
{
  fetch(uri).then(response => response.json()).then(data => addCamerasToMap(data));

  function addCamerasToMap(data)
  {
    data.forEach(item => {
      L.marker([item.latitude, item.longitude]).addToMap;
    });
  }
}
