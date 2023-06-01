
//variable global
let mediaStream = null;

//export function mostrarPrompt(mensaje) {
//    return prompt(mensaje, "Escribe algo");
//}

export function tenerGeolocation() {
	//if (!"geolocation" in navigator) {
	//	return alert("Tu navegador no soporta el acceso a la ubicación. Intenta con otro");
	//}

	//const onUbicacionConcedida = ubicacion => {
	//	 console.log("Tengo la ubicación: ", ubicacion);
	//	//const coordenadas = ubicacion.coords;
	//	return ubicacion;
	//}

	//const onErrorDeUbicacion = err => {
	//	console.log("Error obteniendo ubicación: ", err);
	//}

	//const opcionesDeSolicitud = {
	//	enableHighAccuracy: true, // Alta precisión
	//	maximumAge: 0, // No queremos caché
	//	timeout: 5000 // Esperar solo 5 segundos
	//};
	//// Solicitar
	//navigator.geolocation.getCurrentPosition(onUbicacionConcedida, onErrorDeUbicacion, opcionesDeSolicitud);
	return new Promise((resolve, reject) => {
		if (navigator.geolocation) {
			const opcionesDeSolicitud = {
				enableHighAccuracy: true, // Alta precisión
				maximumAge: 0, // No queremos caché
				timeout: 5000 // Esperar solo 5 segundos
			};
			navigator.geolocation.getCurrentPosition(resolve, reject, opcionesDeSolicitud);
		} else {
			reject("La geolocalización no está soportada por este navegador.");
		}
	}).then((position) => {
		//data de la Promise
		const latitud = position.coords.latitude;
		const longitud = position.coords.longitude;
		let data = {
			coords: {
				latitude: position.coords.latitude + "",
				longitude: position.coords.longitude + ""
			}
		};

		console.log("Latitud: ", latitud, "Longitud: ", longitud);
		return data  ;
	})
		.catch((error) => {
			console.error(error);
		});
}

//export function tomar() {

//	getLocation()
//		.then((position) => {
//			const latitud = position.coords.latitude;
//			const longitud = position.coords.longitude;
//			console.log("Latitud: ", latitud, "Longitud: ", longitud);
//		})
//		.catch((error) => {
//			console.error(error);
//		});
//}


export function descargarArchivo(nombre) {
	var element = document.getElementById("canvas_div_pdf_dowloand");

	try {
		html2pdf(element, {
			margin: 5,
			filename: nombre + ".pdf",
			image: { type: "png", quality: 0.98 },
			html2canvas: {
				scale: 2,
				logging: true,
				dpi: 192,
				letterRendering: true,
			},
			jsPDF: {
				unit: "mm",
				format: "a4",
				orientation: "portrait",
			},
			onePage: true // opcional, fuerza a que todo el contenido esté en una sola página

		});
	} catch (err) {
		 
		alert("Error al imprimir el documento");
	}
 
	 
}


export function mostrarAlerta() {
	return alert("Al ser aprobado podra descargarlo");
}

//export function select() {
//	$(".select2").select2();
//}

//export async function initSelect() {
//	await Promise.resolve($(".select2").select2());
//	console.log("Select2 inicializado");
//}
export function uso() {
	$(document).ready(function () { 
		//placeholder: "Buscar...",
		$(".select2").select2({
			 
			closeOnSelect: true,
		});
		console.log("Select2 inicializado");
	});
}

export function tenerIdSelect() {
	//$('.select2').on("select2:select", function (e) {

	//	alert(e.params.data.id);
	//	console.log(e.params.data.id);
	//});
	var valorSelect2 = $('.select2').val();
	//console.log(valorSelect2);
	return valorSelect2 + "";
	
}

export function cambioDelSelect(mensaje) {
	// $('.select2').val(mensaje).trigger('change.select2');
	 $('.select2').val(mensaje).trigger('change');
	//para borrar
	//$('#mySelect2').val(null).trigger('change');
	//https://select2.org/programmatic-control/methods

}

export function cambiarOverflow() {
	document.body.style.overflow = "hidden";


}

export function cambiarOverflowActivo() {
	document.body.style.overflow = "auto";


}

 

export function permisosVideo() {

	return new Promise((resolve, reject) => {
		navigator.mediaDevices.getUserMedia({
			video: true,
			audio: false })
			.then(stream => {

				// Los permisos fueron concedidos, puedes usar el stream de video aquí
				resolve({ PermisosConcedidos: true});
			})
			.catch(error => {
				// Ocurrió un error al obtener los permisos de la cámara
				resolve({ PermisosConcedidos: false });
			});
	});

}

 

export function TenerCamaras() {

	// Obtener la lista de dispositivos de video disponibles
	return new Promise((resolve, reject) => {
		navigator.mediaDevices.enumerateDevices()
			.then((devices) => {
				let counter = 0;
				const videoDevices = devices.filter((device) => device.kind === "videoinput");
				const arreglo = videoDevices.map((device) => ({
					contador: counter++,
					value: device.deviceId,
					text: device.label || `Device ${device.deviceId}`,
				}));
				resolve(arreglo);
			})
			.catch((error) => {
				reject([]);
			});
	});

}

export function ComenzarCamara(deviceId) {

	return new Promise((resolve, reject) => {
		const videoElement = document.getElementById("videoElement");
 
		//const canvasElement = document.getElementById("canvasElement");

		// Obtener la lista de dispositivos de video disponibles
		navigator.mediaDevices
			.enumerateDevices()
			.then((devices) => {
				const videoDevices = devices.filter(
					(device) => device.kind === "videoinput",
				);

				// Buscar el dispositivo de video por ID o utilizar el primer dispositivo si no se proporciona un ID
				const selectedDevice = deviceId
					? videoDevices.find(
						(device) => device.deviceId === deviceId,
					)
					: videoDevices[0];

				if (selectedDevice) {
					navigator.mediaDevices
						.getUserMedia({
							video: {
								deviceId: { exact: selectedDevice.deviceId },
							},
						})
						.then((stream) => {
							mediaStream = stream;
							videoElement.srcObject = stream;
							resolve({ tipoError: "funciona" });
						})
						.catch((error) => {
							console.error(
								"Error al acceder a la cámara: ",
								error,
							);
							reject({ tipoError: "Error al acceder a la cámara " });
						});
				} else {
					reject({ tipoError: "No se encontró ningún dispositivo de video disponible." });
					 
				}
			})
			.catch((error) => {
				console.error(
					"Error al enumerar los dispositivos: ",
					error,
				);
				resolve({ tipoError: "Error al enumerar los dispositivos: " });
			 
			});

	 
	});



}


export function detenerCamara() {

	if (mediaStream) {
		mediaStream.getTracks().forEach((track) => {
			track.stop();
		});
		mediaStream = null;
		const videoElement = document.getElementById('videoElement');
		videoElement.srcObject = null;
	}

}


export function tomarFotoBase64Camara() {

	const videoElement = document.getElementById("videoElement");
	const canvasElement = document.getElementById("canvasElement");

	return new Promise((resolve, reject) => {
		canvasElement.width = videoElement.videoWidth;
		canvasElement.height = videoElement.videoHeight;

		const context = canvasElement.getContext("2d");
		context.drawImage(
			videoElement,
			0,
			0,
			canvasElement.width,
			canvasElement.height
		);

		const photoDataUrl = canvasElement.toDataURL('image/png');
		//console.log(photoDataUrl);
		resolve(photoDataUrl);
	});

}

 
function otraFuncion() {
	console.log("ESTAMOS EN PERMISOS");
}

 