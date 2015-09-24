
using UnityEngine;
using System.Collections.Generic;

public class MegaLoftLayerCloneSplineRules : MegaLoftLayerRules
{
	public int	curve	= 0;
	public bool snap	= false;

	[ContextMenu("Help")]
	public void Help()
	{
		Application.OpenURL("http://www.west-racing.com/mf/?page_id=2205");
	}

	public override bool Valid()
	{
		if ( LayerEnabled && layerPath && layerPath.splines != null )
		{
			if ( rules.Count > 0 )
				return true;
		}

		return false;
	}

	public override Vector3 GetPos(MegaShapeLoft loft, float ca, float a)
	{
		return Vector3.zero;
	}

	public override bool PrepareLoft(MegaShapeLoft loft, int sc)
	{
		if ( layerPath == null )
			return false;

		if ( rules.Count == 0 )
			return false;

		Random.seed = Seed;

		Init();

		BuildRules();

		float tlen = layerPath.splines[curve].length * Length;

		BuildLoftObjects(tlen);

		for ( int r = 0; r < rules.Count; r++ )
		{
			for ( int i = 0; i < rules[r].lofttris.Count; i++ )
			{
				rules[r].lofttris[i].offset = 0;
				rules[r].lofttris[i].tris = new int[rules[r].lofttris[i].sourcetris.Length * rules[r].usage];
			}
		}

		int vcount = 0;
		int tcount = 0;

		for ( int r = 0; r < loftobjs.Count; r++ )
		{
			vcount += loftobjs[r].verts.Length;
			tcount += loftobjs[r].tris.Length;
		}

		if ( loftverts == null || loftverts.Length != vcount )
			loftverts = new Vector3[vcount];

		if ( loftuvs == null || loftuvs.Length != vcount )
			loftuvs = new Vector2[vcount];

		if ( lofttris == null || lofttris.Length != tcount )
			lofttris = new int[tcount];

		return true;
	}

	Vector3 Deform(Vector3 p, MegaShape path, float percent, float off, Vector3 scale, float removeDof, Vector3 locoff, Vector3 sploff)
	{
		p = tm.MultiplyPoint3x4(p);
		p.z += off;
		p.x *= scale.x;
		p.y *= scale.y;
		p.z *= scale.z;

		p += locoff;
		float alpha = (p.z / path.splines[curve].length) + percent;
		float tw1 = 0.0f;

		Vector3 ps	= path.InterpCurve3D(curve, alpha, path.normalizedInterp, ref tw1) + sploff;
		Vector3 ps1	= path.InterpCurve3D(curve, alpha + (tangent * 0.001f), path.normalizedInterp) + sploff;

		if ( path.splines[curve].closed )
			alpha = Mathf.Repeat(alpha, 1.0f);
		else
			alpha = Mathf.Clamp01(alpha);

		tw = Quaternion.AngleAxis((twist * twistCrv.Evaluate(alpha)) + tw1, Vector3.forward);

		Vector3 relativePos = ps1 - ps;
		relativePos.y *= removeDof;

		Quaternion rotation = Quaternion.LookRotation(relativePos) * tw;
		//wtm.SetTRS(ps, rotation, Vector3.one);
		MegaMatrix.SetTR(ref wtm, ps, rotation);

		wtm = mat * wtm;

		p.z = 0.0f;
		return wtm.MultiplyPoint3x4(p);
	}

	public override int BuildMesh(MegaShapeLoft loft, int triindex)
	{
		if ( tangent < 0.1f )
			tangent = 0.1f;

		//mat = layerPath.transform.localToWorldMatrix;
		//mat = transform.localToWorldMatrix * layerPath.transform.worldToLocalMatrix;	// * transform.worldToLocalMatrix;	//mat = surfaceLoft.transform.localToWorldMatrix;
		mat = Matrix4x4.identity;
		tm = Matrix4x4.identity;

		MegaMatrix.Rotate(ref tm, Mathf.Deg2Rad * tmrot);
		float off = 0.0f;
		int trioff = 0;
		int vi = 0;

		Vector3 sploff = Vector3.zero;
		if ( snap )
			sploff = layerPath.splines[0].knots[0].p - layerPath.splines[curve].knots[0].p;

		for ( int r = 0; r < rules.Count; r++ )
		{
			for ( int i = 0; i < rules[r].lofttris.Count; i++ )
				rules[r].lofttris[i].offset = 0;
		}

		for ( int r = 0; r < loftobjs.Count; r++ )
		{
			MegaLoftRule obj = loftobjs[r];

			Vector3 sscl = (scale + obj.scale) * GlobalScale;
			Vector3 soff = Vector3.Scale(offset + obj.offset, sscl);

			off -= obj.bounds.min[(int)axis];
			off += (obj.gapin * obj.bounds.size[(int)axis]);

			for ( int i = 0; i < obj.verts.Length; i++ )
			{
				Vector3 p = obj.verts[i];

				p = Deform(p, layerPath, start, off, sscl, RemoveDof, soff, sploff);
				loftverts[vi] = p;
				loftuvs[vi++] = obj.uvs[i];
			}

			for ( int i = 0; i < obj.lofttris.Count; i++ )
			{
				int toff = obj.lofttris[i].offset;

				for ( int t = 0; t < obj.lofttris[i].sourcetris.Length; t++ )
					obj.lofttris[i].tris[toff++] = obj.lofttris[i].sourcetris[t] + trioff + triindex;

				obj.lofttris[i].offset = toff;
			}

			off += obj.bounds.max[(int)axis];
			off += (obj.gapout * obj.bounds.size[(int)axis]);
			trioff = vi;
		}

		return triindex;
	}

	public override MegaLoftLayerBase Copy(GameObject go)
	{
		MegaLoftLayerCloneSplineRules layer =  go.AddComponent<MegaLoftLayerCloneSplineRules>();

		Copy(this, layer);

		loftverts = null;
		loftuvs = null;
		loftcols = null;
		lofttris = null;

		return null;
	}

}
