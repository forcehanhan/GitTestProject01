/*
 * 时间：2020年3月21日08:57:02
 * 题目：查找游戏对象Find()
 * 实现目的：1、掌握Find()函数,会查找游戏对象、组件
 *                  2、GameObject.Find()不能查找隐藏的游戏对象
 * 操作步骤：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>_025_Find：类，查询游戏对象。</summary>
public class _025_GameObject_Find : MonoBehaviour
{
    private GameObject obj1;
    private GameObject obj2;
    private GameObject obj3;
    private GameObject sameTag;
    private GameObject[] spheres;

    private Transform tran;

    void Start() {
        //一、Find(string name)
        //1、查找Hierarchy面板中的游戏对象Cube1
        obj1 = GameObject.Find("Cube1");
        Debug.Log("===>1、找到的物体是:" + obj1.name);
        //2、调用Cube1上的脚本中的方法，PrintInfo为Cube1上的脚本，PrintMsg()是该脚本中的方法
        obj1.GetComponent<PrintInfo>().PrintMsg();

        //二、逐级查找：Find( name1/name2)：name1是name2的父级
        //1、通过层级,逐级查找:查询子层级中的Cube3
        obj1 = GameObject.Find("FindGameObject/Cube3");
        Debug.Log("===>2、找到的物体是:" + obj1.name);

        //三、逐级查找：Find( name1/name2/name3):保证层级正确.
        //1、通过层级,逐级查找:查询子层级中的Cube5
        obj1 = GameObject.Find("FindGameObject/Cube4/Cube5");
        obj1.GetComponent<Renderer>().material.color = Color.white;
        Debug.Log("===>3、找到的物体是:" + obj1.name);

        //四、逐级查找：层级越来越深，当资源比较多的时候，这样比较快速
        //1、查询游戏对象Cube6,并销毁它
        obj1 = GameObject.Find("FindGameObject/Cube4/Cube5/Cube6");
        Debug.Log("===>4、销毁Cube6");
        //2、销毁
        Destroy(obj1);

        //五、遍历查找:查找整个Hierarchy范围
        //1、查询子层级中的Cube5
        obj1 = GameObject.Find("Cube5");
        Debug.Log("===>5、找到的物体是:" + obj1.name);



        //六、查找到Cube2，调用它自身的方法
        //1、查找到Cube2
        obj2 = GameObject.Find("Cube2");
        Debug.Log("===>6、找到的物体是:" + obj2.name);
        //2、调用Cube2上脚本中方法，将其自身的Collider组件销毁
        obj2.GetComponent<DestroyObject>().DestroyGameObject(obj2.GetComponent<Collider>());

        //八、FindGameObjectWithTag(string tag)
        //1、通过标签查询Cube11
        obj3 = GameObject.FindGameObjectWithTag("BoxTag");
        Debug.Log("===>7、找到的物体是:" + obj3.name);
        Debug.Log("===>8、物体的标签是:" + obj3.tag);


        //九、FindGameObjectsWithTag(string tag)
        //1、查找标签一样的游戏对象，因为是数量较多且标签一样的，所以用数组的形式
        spheres = GameObject.FindGameObjectsWithTag("SphereTag");
        foreach (GameObject sphere in spheres)
        {
            Debug.Log("===>9、物体的标签是:" + sphere.tag);//游戏对象的标签
            Debug.Log("===>10、找到的物体是:" + sphere);//打印遍历的游戏对象
        }

        //十、 FindWithTag(string tag)
        //FindWithTag()查找到为止,只查找一次
        sameTag = GameObject.FindWithTag("HelloWorldTag");
        Debug.Log("===>11、物体的名称是:" + sameTag.name);

        //十一、 FindWithTag(string tag)
        //和transform.Find(""Cube7/Cube8/Cube9")是一样的
        tran = GameObject.Find("Cube7").gameObject.transform.FindChild("Cube8").FindChild("Cube9");
            Debug.Log("===>12、找到的物体是:" + tran.name);
    }


    void Update() {

    }
}
