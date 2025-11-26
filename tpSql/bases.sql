USE testsql;

-- Niveau 1 : Questions basiques
	-- 1. S�lectionnez tous les chiens avec leur nom, leur race et leur poids.
	SELECT name,breed,weight 
	FROM Dogs

	-- 2. Listez tous les propri�taires (pr�nom et nom).
	SELECT *
	FROM People 

	-- 3. R�cup�rez les chiens qui n'ont pas de ma�tre.
	SELECT *
	FROM Dogs
	WHERE owner_id IS NULL

	-- 4. S�lectionnez tous les chiens de race "Labrador".
	SELECT *
	FROM Dogs
	WHERE breed = 'Labrador'

-- Niveau 2 : Jointures simples (INNER JOIN)
	-- 5. Affichez le nom des chiens avec le pr�nom et le nom de leur ma�tre.
	SELECT Dogs.name AS dog_name, People.first_name, People.last_name
	FROM People
	INNER JOIN Dogs ON Dogs.owner_id = People.id

	-- 6. R�cup�rez les ma�tres qui poss�dent un chien pesant plus de 20 kg.
	SELECT Dogs.name AS dog_name, Dogs.size, People.first_name, People.last_name
	FROM People
	INNER JOIN Dogs ON Dogs.owner_id = People.id
	where Dogs.size > 20

-- Niveau 3 : LEFT JOIN
	-- 7. Affichez tous les propri�taires et les chiens qu'ils poss�dent, y compris les propri�taires sans chien.
	SELECT Dogs.name AS dog_name, People.first_name, People.last_name
	FROM People
	LEFT JOIN Dogs ON Dogs.owner_id = People.id

	-- 8. Listez tous les chiens, avec leurs ma�tres s'ils en ont, sinon affichez "No Owner".
	SELECT d.name AS dog_name, d.breed, d.age, d.weight,
		CASE 
			WHEN p.id IS NULL THEN 'No Owner'
			ELSE p.first_name + ' ' + p.last_name
		END AS owner_name
	FROM Dogs d
	LEFT JOIN People p ON p.id = d.owner_id


-- Niveau 4 : FULL OUTER JOIN
	-- 9. R�cup�rez tous les chiens et tous les ma�tres, m�me ceux sans correspondance.
	SELECT 
		CASE 
			WHEN d.id IS NULL THEN 'No Dogs'
			ELSE d.name 
		END AS dogs_name,
		CASE 
			WHEN p.id IS NULL THEN 'No Owner'
			ELSE p.first_name + ' ' + p.last_name
		END AS owner_name
	FROM Dogs d
	FULL JOIN People p ON p.id = d.owner_id

-- Niveau 5 : Filtrage avanc�
	-- 10. Affichez les chiens dont le poids est sup�rieur � 10 kg mais inf�rieur � 30 kg.
	SELECT *
	FROM Dogs
	WHERE weight BETWEEN 11 AND 29

	-- 11. R�cup�rez les chiens de ma�tres habitant dans la ville "123 Main St".
	SELECT Dogs.name AS dog_name, People.first_name, People.last_name
	FROM People
	INNER JOIN Dogs ON Dogs.owner_id = People.id
	WHERE People.address = '123 Main St'

-- Niveau 6 : Agr�gats et GROUP BY
	-- 12. Affichez le nombre de chiens pour chaque ma�tre.
	SELECT p.id, p.first_name, p.last_name,p.address, COUNT(d.id) AS nb_dogs
	FROM People p
	LEFT JOIN Dogs d ON d.owner_id = p.id
	GROUP BY p.id, p.first_name, p.last_name, p.address

	-- 13. Calculez le poids total des chiens appartenant � chaque ma�tre.
	SELECT p.id, p.first_name, p.last_name,p.address,
	CASE 
        WHEN  SUM(d.weight) IS NULL THEN 0
        ELSE  SUM(d.weight)
    END AS nb_weight
	FROM People p
	LEFT JOIN Dogs d ON d.owner_id = p.id
	GROUP BY p.id, p.first_name, p.last_name, p.address

-- Niveau 7 : Sous-requ�tes
	-- 14. R�cup�rez les ma�tres qui poss�dent le chien le plus lourd.
	SELECT p.*,d.weight
	FROM People p
	INNER JOIN Dogs d ON d.owner_id = p.id
	WHERE d.weight = (
		SELECT MAX(weight) 
		FROM Dogs
	)

	-- 15. Affichez les chiens qui ont un ma�tre dont l'�ge est sup�rieur � 40 ans.
	SELECT d.*, p.age
	FROM Dogs d
	INNER JOIN People p ON p.id = d.owner_id
	WHERE p.id IN (
		SELECT id
		FROM People
		WHERE age > 40
	)

-- Niveau 8 : Cas complexes
	-- 16. Listez les ma�tres n'ayant pas de chien.
		SELECT p.*,d.name AS dog_name
		FROM People p
		LEFT JOIN Dogs d ON d.owner_id = p.id
		WHERE d.id IS NULL

	-- 17. Affichez la race la plus courante parmi les chiens.
	SELECT TOP 1 breed, COUNT(*) AS nb_dogs
	FROM Dogs
	GROUP BY breed
	ORDER BY nb_dogs DESC

	-- 18. Listez tous les ma�tres qui poss�dent au moins deux chiens.
	SELECT p.id, p.first_name, p.last_name, p.address, COUNT(d.id) AS nb_dogs
	FROM People p
	LEFT JOIN Dogs d ON d.owner_id = p.id
	GROUP BY p.id, p.first_name, p.last_name, p.address
	HAVING COUNT(d.id) > 1

-- Niveau 9 : FULL OUTER JOIN combin�
	-- 19. R�cup�rez une liste combin�e de chiens sans ma�tres et de ma�tres sans chiens.
	SELECT 
		CASE 
			WHEN d.name IS NULL THEN 'No Dogs' 
			ELSE d.name 
		END AS dog_name,
		CASE 
			WHEN p.id IS NULL THEN 'No Owner' 
			ELSE p.first_name + ' ' + p.last_name 
		END AS owner_name
	FROM Dogs d
	FULL OUTER JOIN People p ON d.owner_id = p.id
	ORDER BY owner_name


	-- 20. Affichez le ma�tre et ses chien associ�s avec somme de leur tailles respectives (taille du ma�tre et des chiens).
