using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    void Start()
    {
        Nube(7f,7.09f,7f);
        Nube(10.87f,7f,6f);   
        Nube(8.45f,9.66f,6f);
        Nube(-7f,5.5f,-7f);
        Nube(-1f,7f,6f);
        Nube(3.77f,8.45f,6f);
        Bote(8.11f, 0.5f, -5.22f);
        Bote(-5.11f, 0.5f, 1.22f);
        Plane(-7.19f, 7.52f,-2); 
        Globe(6.81f, 4.28f, 5.93f);
        Globe(4.81f, 3.28f, 3.93f);
        Globe(1.32f, 6.3f, 2.93f);
        GameObject Base = GameObject.CreatePrimitive(PrimitiveType.Plane);
        Base.transform.position = new Vector3(0, 0, 0);
        Base.transform.localScale = new Vector3(3, 1, 2);
        Base.GetComponent<Renderer>().material.color= new Color(0.1843f,0.4705f,1);
    }
 
    void Plane(float x, float y, float z){
        GameObject body = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        body.transform.position = new Vector3(x,y,z);
        body.transform.localScale = new Vector3(1, 1, 1);
        body.transform.rotation = Quaternion.Euler(0, 0, 90f);
        body.GetComponent<Renderer>().material.color= new Color(0.1415f,0.1216f,0.1161f);
        GameObject back = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        back.transform.parent = body.transform;
        back.transform.localPosition = new Vector3(0, -1f, 0);
        back.transform.localScale = new Vector3(0.5f, 0.3f, 0.5f);
        back.transform.rotation = Quaternion.Euler(0, 0, 90f);
        back.GetComponent<Renderer>().material.color= new Color(0.1415f,0.1216f,0.1161f);
        GameObject Wings = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Wings.transform.parent = body.transform;
        Wings.transform.localScale = new Vector3(0.5f, 0.2f, 2f);
        Wings.transform.localPosition = new Vector3(0, 0, 0);
        Wings.GetComponent<Renderer>().material.color= new Color(0.1415f,0.1216f,0.1161f);
    }
 
    void Globe(float x, float y, float z){ 
        GameObject Up = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Up.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        Up.transform.position = new Vector3(x,y,z);
        Up.GetComponent<Renderer>().material.color= new Color(1,0.5293f,0);
        GameObject arriba = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        arriba.transform.parent = Up.transform;
        arriba.transform.localPosition = new Vector3(0, -0.5f, 0);
        arriba.transform.localScale = new Vector3(0.5f, 0.1f, 0.5f);
        arriba.GetComponent<Renderer>().material.color= new Color(1,0.2174f,0);
        GameObject canasta = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        canasta.transform.parent = Up.transform;
        canasta.transform.localPosition = new Vector3(0, -1.2f, 0);
        canasta.transform.localScale = new Vector3(0.5f, 0.2f, 0.5f);
        canasta.GetComponent<Renderer>().material.color= new Color(0.3379f,0.2290f,0.2290f);
        GameObject lightGameObject = new GameObject("The Light");
        Light lightComp = lightGameObject.AddComponent<Light>();
        lightComp.color = Color.yellow;
        lightGameObject.transform.parent = arriba.transform;
        lightGameObject.transform.localPosition = new Vector3(0, -1, 0);
    }
 
    void Bote(float x, float y, float z){ 
        Vector3[] Vertices1 = new Vector3[5];
    	Vector2[] uv = new Vector2[5];
        Vertices1[0] = new Vector3(0,0,0);
        Vertices1[1] = new Vector3(1f,0,0.5f);
        Vertices1[2] = new Vector3(1f,0,-0.5f);
        Vertices1[3] = new Vector3(1f,-1,-0.5f);
        Vertices1[4] = new Vector3(1f,-1,0.5f);
        uv[0] = new Vector3(0,0,0);
        uv[1] = new Vector3(1f,0,0.5f);
        uv[2] = new Vector3(1f,0,-0.5f);
        uv[3] = new Vector3(1f,-1,-0.5f);
        uv[4] = new Vector3(1f,-1,0.5f);

		Mesh mesh = new Mesh();
		mesh.vertices=Vertices1;
		mesh.uv=uv;
		mesh.triangles=new int[]{0,1,2,0,2,3,0,3,4,0,4,1,2,1,4,2,4,3};

        GameObject Centro = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Centro.transform.localScale = new Vector3(2, 1, 1);
        Centro.transform.position = new Vector3(x,y,z);
        Centro.GetComponent<Renderer>().material.color= new Color(0.3379f,0.2290f,0.2290f);
        GameObject Triangle = new GameObject("Triangle", typeof(MeshFilter), typeof(MeshRenderer));
        Triangle.transform.parent = Centro.transform;
        Triangle.transform.localScale = new Vector3(1,1,1);
        Triangle.transform.localPosition = new Vector3(-1.5f,0.5f,0);
		Triangle.GetComponent<MeshFilter>().mesh = mesh;
        Triangle.GetComponent<Renderer>().material.color= new Color(0.3379f,0.2290f,0.2290f);
        GameObject Triangle2 = new GameObject("Triangle2", typeof(MeshFilter), typeof(MeshRenderer));
        Triangle2.transform.parent = Centro.transform;
        Triangle2.transform.rotation = Quaternion.Euler(0,180f, 0);
        Triangle2.transform.localScale = new Vector3(1,1,1);
        Triangle2.transform.localPosition = new Vector3(1.5f,0.5f,0);
		Triangle2.GetComponent<MeshFilter>().mesh = mesh;
        Triangle2.GetComponent<Renderer>().material.color= new Color(0.3379f,0.2290f,0.2290f);
        GameObject Triangle3 = new GameObject("Triangle2", typeof(MeshFilter), typeof(MeshRenderer));
        Triangle3.transform.parent = Centro.transform;
        Triangle3.transform.rotation = Quaternion.Euler(270f,-45f,45f);
        Triangle3.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
        Triangle3.transform.localPosition = new Vector3(-0.5F,1.5F,0);
		Triangle3.GetComponent<MeshFilter>().mesh = mesh;
        Triangle3.GetComponent<Renderer>().material.color= new Color(0.8584f,0.0242f,0.1429f);
    }
    void Nube(float x, float y, float z){ 
        GameObject nube1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        nube1.transform.localScale = new Vector3(1,1,1);
        nube1.transform.position = new Vector3(x,y,z);
        nube1.GetComponent<Renderer>().material.color= new Color(0.5f,0.8292f,1);
        GameObject nube2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        nube2.transform.parent = nube1.transform;
        nube2.transform.localPosition = new Vector3(0,-0.5F,0);
        nube2.GetComponent<Renderer>().material.color= new Color(0.5f,0.8292f,1);
        GameObject nube3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        nube3.transform.parent = nube1.transform;
        nube3.transform.localPosition = new Vector3(-0.5F,-0.3F,0);
        nube3.GetComponent<Renderer>().material.color= new Color(0.5f,0.8292f,1);
        GameObject nube4 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        nube4.transform.parent = nube1.transform;
        nube4.transform.localPosition = new Vector3(0.5F,-0.3F,0);
        nube4.GetComponent<Renderer>().material.color= new Color(0.5f,0.8292f,1);
        GameObject nube5 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        nube5.transform.parent = nube1.transform;
        nube5.transform.localPosition = new Vector3(-0.8F,-0.6F,0);
        nube5.GetComponent<Renderer>().material.color= new Color(0.5f,0.8292f,1);
        GameObject nube6 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        nube6.transform.parent = nube1.transform;
        nube6.transform.localPosition = new Vector3(0.8F,-0.6F,0);
        nube6.GetComponent<Renderer>().material.color= new Color(0.5f,0.8292f,1);
    }

}
