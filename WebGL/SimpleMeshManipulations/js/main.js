var width = window.innerWidth, height = window.innerHeight;
var view_angle=45,  aspect = width/height, near = 0.1, far=1000;

var container = $('#container');

var renderer = new THREE.WebGLRenderer();
var camera = new THREE.PerspectiveCamera(view_angle, aspect, near, far);
var scene = new THREE.Scene();
scene.add(camera);
camera.position.z = 200;


var cubeGeometry = new THREE.CubeGeometry(50,50,50);
var cubeMaterial = new THREE.MeshBasicMaterial({color: 0xff0000});
var cube = new THREE.Mesh(cubeGeometry, cubeMaterial);
scene.add(cube);

renderer.setSize(width, height);
container.append(renderer.domElement);
animation();

function animation(){
    requestAnimationFrame(animation);
    cube.rotation.y += Math.PI * 1 / 180;
    cube.rotation.z += Math.PI * 1 / 180;
    renderer.render(scene, camera);
}
